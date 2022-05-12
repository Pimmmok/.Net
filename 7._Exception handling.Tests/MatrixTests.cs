using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace _7._Exception_handling.Tests
{
    public class Tests
    {
        private static double[,] GetArrayForTestMethod(string key)
        {
            return key switch
            {
                "ArrayOneForOptionOne" => new double[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } },
                "ArrayTwoForOptionOne" => new double[2, 3] { { 6, 5, 4 }, { 3, 2, 1 } },
                "ArrayOneForOptionTwo" => new double[2, 3] { { -1, -2, 3 }, { 4, -5, 6 } },
                "ArrayTwoForOptionTwo" => new double[2, 3] { { 6, -5, 4 }, { 3, 2, -1 } },
                "ArrayOneForOptionThree" => new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 4.5, 5.7, 6.8 } },
                "ArrayTwoForOptionThree" => new double[3, 3] { { 6, 5, 4 }, { 3, 2, 1 }, { 10.0, -11.0, 99.0 } },
                "ArrayResult_operatorAddForOptionOne" => new double[2, 3] { { 7, 7, 7 }, { 7, 7, 7 } },
                "ArrayResult_operatorAddForOptionTwo" => new double[2, 3] { { 5, -7, 7 }, { 7, -3, 5 } },
                "ArrayResult_operatorAddForOptionThree" => new double[3, 3] { { 7, 7, 7 }, { 7, 7, 7 }, { 14.5, -5.3, 105.8 } },
                "ArrayResult_operatorMinusForOptionOne" => new double[2, 3] { { -5, -3,-1 }, { 1, 3, 5 } },
                "ArrayResult_operatorMinusForOptionTwo" => new double[2, 3] { { -7, 3,-1 }, { 1, -7, 7 } },
                "ArrayResult_operatorMinusForOptionThree" => new double[3, 3] { { -5,-3,-1 }, { 1, 3, 5 }, { -5.5, 16.7, -92.2 } },
                "ArrayOneMultiplicationForOptionOne" => new double[2, 2] { { -2, 1 }, { 5, 4 } },
                "ArrayTwoMultiplicationForOptionOne" => new double[2, 1] { { 3 }, { -1 } },
                "ArrayResult_operatorMultiplicationForOptionOne" => new double[2, 1] { { -7 }, { 11 } },
                "ArrayOneMultiplicationForOptionTwo" => new double[3, 3] { { 5, 8 ,-4}, { 6, 9, -5 }, { 4, 7, -3} },
                "ArrayTwoMultiplicationForOptionTwo" => new double[3, 1] { { 2 }, { -3 }, { 1} },
                "ArrayResult_operatorMultiplicationForOptionTwo" => new double[3, 1] { { -18 }, { -20 }, { -16 } },
                "ArrayOneMultiplicationForOptionThree" => new double[3, 3] { { 5, 8, -4 }, { 6, 9, -5 }, { 4, 7, -3 } },
                "ArrayTwoMultiplicationForOptionThree" => new double[3, 3] { {3, 2 ,5}, {4, -1, 3 }, { 9, 6, 5 } },
                "ArrayResult_operatorMultiplicationForOptionThree" => new double[3, 3] { { 11, -22, 29 }, { 9, -27, 32 }, { 13, -17, 26 } },
                _ => new double[2, 3] { { 0, 0, 0 }, { 0, 0, 0 } },
            };
        }

        [TestCase("ArrayOneForOptionOne", "ArrayTwoForOptionOne", "ArrayResult_operatorAddForOptionOne")]
        [TestCase("ArrayOneForOptionTwo", "ArrayTwoForOptionTwo", "ArrayResult_operatorAddForOptionTwo")]
        [TestCase("ArrayOneForOptionThree", "ArrayTwoForOptionThree", "ArrayResult_operatorAddForOptionThree")]
        public void OperatorPlus_SumOfMatrices_ShouldBeCalculatedCorrectly(string keyOne, string keyTwo, string keyResult)
        {
            Matrix matrixOne = new Matrix(GetArrayForTestMethod(keyOne));
            Matrix matrixTwo = new Matrix(GetArrayForTestMethod(keyTwo));
            Matrix expected = new Matrix(GetArrayForTestMethod(keyResult));
            Matrix actual = matrixOne + matrixTwo;
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase("ArrayOneForOptionOne", "ArrayTwoForOptionOne", "ArrayResult_operatorMinusForOptionOne")]
        [TestCase("ArrayOneForOptionTwo", "ArrayTwoForOptionTwo", "ArrayResult_operatorMinusForOptionTwo")]
        [TestCase("ArrayOneForOptionThree", "ArrayTwoForOptionThree", "ArrayResult_operatorMinusForOptionThree")]
        public void OperatorMinus_MatricesSubtraction_ShouldBeCalculatedCorrectly(string keyOne,
                                                                                  string keyTwo,
                                                                                  string keyResult)
        {
            Matrix matrixOne = new Matrix(GetArrayForTestMethod(keyOne));
            Matrix matrixTwo = new Matrix(GetArrayForTestMethod(keyTwo));
            Matrix expected = new Matrix(GetArrayForTestMethod(keyResult));
            Matrix actual = matrixOne - matrixTwo;
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase("ArrayOneMultiplicationForOptionOne", "ArrayTwoMultiplicationForOptionOne", "ArrayResult_operatorMultiplicationForOptionOne")]
        [TestCase("ArrayOneMultiplicationForOptionTwo", "ArrayTwoMultiplicationForOptionTwo", "ArrayResult_operatorMultiplicationForOptionTwo")]
        [TestCase("ArrayOneMultiplicationForOptionThree", "ArrayTwoMultiplicationForOptionThree", "ArrayResult_operatorMultiplicationForOptionThree")]
        public void OperatorMultiplication_MatricesMultiplication_ShouldBeCalculatedCorrectly(string keyOne,
                                                                                            string keyTwo,
                                                                                            string keyResult)
        {
            Matrix matrixOne = new Matrix(GetArrayForTestMethod(keyOne));
            Matrix matrixTwo = new Matrix(GetArrayForTestMethod(keyTwo));
            Matrix expected = new Matrix(GetArrayForTestMethod(keyResult));
            Matrix actual = matrixOne * matrixTwo;
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [Test]
        public void OperatorPlus_TestException_ShouldBeMatrixOperationException()
        {
            MatrixOperationException matrixOperationException = Assert.Throws<MatrixOperationException>(() => 
            OperatorPlus_SumOfMatrices_ShouldBeCalculatedCorrectly("ArrayOneForOptionOne",
                                                                   "ArrayTwoForOptionThree",
                                                                   "ArrayResult_operatorAddForOptionThree"));
            Assert.That(matrixOperationException.OperationName, Is.EqualTo("Matrix addition"));
        }

        [Test]
        public void OperatorMinus_TestException_ShouldBeMatrixOperationException()
        {
            MatrixOperationException matrixOperationException = Assert.Throws<MatrixOperationException>(() => 
            OperatorMinus_MatricesSubtraction_ShouldBeCalculatedCorrectly("ArrayOneForOptionOne",
                                                                          "ArrayTwoForOptionThree",
                                                                          "ArrayResult_operatorMinusForOptionThree"));
            Assert.That(matrixOperationException.OperationName, Is.EqualTo("Matrix subtraction"));
        }

        [Test]
        public void OperatorMultiplication_TestException_ShouldBeMatrixOperationException()
        {
            MatrixOperationException matrixOperationException = Assert.Throws<MatrixOperationException>(() => 
            OperatorMultiplication_MatricesMultiplication_ShouldBeCalculatedCorrectly("ArrayOneForOptionOne",
                                                                                      "ArrayTwoForOptionOne",
                                                                                      "ArrayResult_operatorMultiplicationForOptionOne"));
            Assert.That(matrixOperationException.OperationName, Is.EqualTo("Matrix multiplication"));
        }
    }
}
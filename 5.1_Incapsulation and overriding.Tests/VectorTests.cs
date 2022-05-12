using NUnit.Framework;

namespace _5._1_Incapsulation_and_overriding.Tests
{
    public class VectorTests
    {

        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 3, 2, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 12, 17, 19 }, new double[] { 12, 11, 19 }, ExpectedResult = false)]
        public bool OperatorEquals_CheckEquality_ShouldBeTrue(double[] vectorOneValues, double[] vectorTwoValues)

        {
            Vector vectorOne = new Vector(vectorOneValues[0], vectorOneValues[1], vectorOneValues[2]);
            Vector vectorTwo = new Vector(vectorTwoValues[0], vectorTwoValues[1], vectorTwoValues[2]);
            return vectorOne == vectorTwo;
        }

        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 3, 2, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 12, 17, 19 }, new double[] { 12, 11, 19 }, ExpectedResult = true)]
        public bool OperatorNotEquals_CheckInequality_ShouldBeTrue(double[] vectorOneValues, double[] vectorTwoValues)

        {
            Vector vectorOne = new Vector(vectorOneValues[0], vectorOneValues[1], vectorOneValues[2]);
            Vector vectorTwo = new Vector(vectorTwoValues[0], vectorTwoValues[1], vectorTwoValues[2]);
            return vectorOne != vectorTwo;
        }

        [TestCase(new double[] { 1, 1, 1 }, new double[] { 2, 2, 2 }, new double[] { 3, 3, 3 })]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 1 }, new double[] { 2, 4, 4 })]
        [TestCase(new double[] { 1, 1, 4 }, new double[] { 2, 3, 3 }, new double[] { 3, 4, 7 })]
        public void OperatorPlus_SumOfVectors_ShouldBeCalculatedCorrectly(double[] vectorOneValues,
                                                                          double[] vectorTwoValues,
                                                                          double[] vectorExpectedValues)
        {
            Vector vectorOne = new Vector(vectorOneValues[0], vectorOneValues[1], vectorOneValues[2]);
            Vector vectorTwo = new Vector(vectorTwoValues[0], vectorTwoValues[1], vectorTwoValues[2]);
            Vector expected = new Vector(vectorExpectedValues[0], vectorExpectedValues[1], vectorExpectedValues[2]);
            Vector actual = vectorOne + vectorTwo;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 1, 1, 1 }, new double[] { 2, 2, 2 }, new double[] { -1, -1, -1 })]
        [TestCase(new double[] { 10, 12, 3 }, new double[] { 1, 2, 1 }, new double[] { 9, 10, 2 })]
        [TestCase(new double[] { 11, 11, 40 }, new double[] { 2, 3, 33 }, new double[] { 9, 8, 7 })]
        public void OperatorMinus_VectorSubtraction_ShouldBeCalculatedCorrectly(double[] vectorOneValues,
                                                                                double[] vectorTwoValues,
                                                                                double[] vectorExpectedValues)
        {
            Vector vectorOne = new Vector(vectorOneValues[0], vectorOneValues[1], vectorOneValues[2]);
            Vector vectorTwo = new Vector(vectorTwoValues[0], vectorTwoValues[1], vectorTwoValues[2]);
            Vector expected = new Vector(vectorExpectedValues[0], vectorExpectedValues[1], vectorExpectedValues[2]);
            Vector actual = vectorOne - vectorTwo;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 11, 12, 17 }, new double[] { 33, 41, 77 }, new double[] { 227, -286, 55 })]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 0, 2, 7 }, new double[] { 8, -7, 2 })]
        [TestCase(new double[] { 7, 11, 17 }, new double[] { -19, -21, 3 }, new double[] { 390, -344, 62 })]
        public void OperatorMultiplication_VectorMultiplication_ShouldBeCalculatedCorrectly(double[] vectorOneValues,
                                                                                            double[] vectorTwoValues,
                                                                                            double[] vectorExpectedValues)
        {
            Vector vectorOne = new Vector(vectorOneValues[0], vectorOneValues[1], vectorOneValues[2]);
            Vector vectorTwo = new Vector(vectorTwoValues[0], vectorTwoValues[1], vectorTwoValues[2]);
            Vector expected = new Vector(vectorExpectedValues[0], vectorExpectedValues[1], vectorExpectedValues[2]);
            Vector actual = vectorOne * vectorTwo;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 1, 0, 3 }, new double[] { 0, 1, 2 }, 0.001, 6)]
        [TestCase(new double[] { 10, -12, 17 }, new double[] { -8, 77, 19 }, 0.001, -681)]
        [TestCase(new double[] { 11, 99, 101 }, new double[] { 17, 11, 33 }, 0.001, 4609)]
        public void CalculateScalarMultiplication_ScalarMultiplicationVectors_ShouldBeCalculatedCorrectly(double[] vectorOneValues,
                                                                                                          double[] vectorTwoValues,
                                                                                                          double precision,
                                                                                                          double expected)
        {
            Vector vectorOne = new Vector(vectorOneValues[0], vectorOneValues[1], vectorOneValues[2]);
            Vector vectorTwo = new Vector(vectorTwoValues[0], vectorTwoValues[1], vectorTwoValues[2]);
            double actual = vectorOne.CalculateScalarMultiplication(vectorTwo);
            Assert.AreEqual(expected, actual, precision);
        }

        [TestCase(new double[] { 11, -22, 33 }, 0.001, 41.1582)]
        [TestCase(new double[] { 11, -22, 33 }, 0.001, 41.1582)]
        [TestCase(new double[] { 11, -22, 33 }, 0.001, 41.1582)]
        public void CalculateLength_VectorLength_ShouldBeCalculatedCorrectly(double[] vectorValues,
                                                                             double precision,
                                                                             double expected)
        {
            Vector vectorOne = new Vector(vectorValues[0], vectorValues[1], vectorValues[2]);

            double actual = vectorOne.CalculateLength();
            Assert.AreEqual(expected, actual, precision);
        }

        [TestCase(new double[] { 3, 3, 3 }, new double[] { 3, 3, 3 }, 0.001, 0)]
        [TestCase(new double[] { 11, 22, 33 }, new double[] { 33, 22, 11 }, 0.001, 44.415)]
        [TestCase(new double[] { 100, 150, 201 }, new double[] { -100, 200, -203 }, 0.001, 104.781)]
        public void CalculateAngleBetweenVectors_AngleBetweenVectors_ShouldBeCalculatedCorrectly(double[] vectorOneValues,
                                                                                                 double[] vectorTwoValues,
                                                                                                 double precision,
                                                                                                 double expected)
        {
            Vector vectorOne = new Vector(vectorOneValues[0], vectorOneValues[1], vectorOneValues[2]);
            Vector vectorTwo = new Vector(vectorTwoValues[0], vectorTwoValues[1], vectorTwoValues[2]);
            double actual = vectorOne.CalculateAngleBetweenVectors(vectorTwo);
            Assert.AreEqual(expected, actual, precision);
        }
    }
}


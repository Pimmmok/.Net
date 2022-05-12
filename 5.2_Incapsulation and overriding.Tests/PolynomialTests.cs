using NUnit.Framework;


namespace _5._2_Incapsulation_and_overriding.Tests
{
    public class PolynomialTests
    {
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 3, 3 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 3, 3 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = true)]
        public bool OperatorEquals_CheckEquality_ShouldBeTrue(double[] arrayOfCoefficientsOne, double[] arrayOfCoefficientsTwo)
        {
            Polynomial polynomialOne = new Polynomial(arrayOfCoefficientsOne);
            Polynomial polynomialTwo = new Polynomial(arrayOfCoefficientsTwo);
            return polynomialOne == polynomialTwo;
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 3, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 3, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        public bool OperatorNotEquals_CheckInequality_ShouldBeTrue(double[] arrayOfCoefficientsOne, double[] arrayOfCoefficientsTwo)
        {
            Polynomial polynomialOne = new Polynomial(arrayOfCoefficientsOne);
            Polynomial polynomialTwo = new Polynomial(arrayOfCoefficientsTwo);
            return polynomialOne != polynomialTwo;
        }
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 3, 3 }, new double[] { 2, 5, 6 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 3, 3 }, new double[] { 1, 3, 4 })]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 4 }, new double[] { 2, 4, 7 })]

        public void OperatorPlus_SumOfPolynomials_ShouldBeCalculatedCorrectly(double[] arrayOfCoefficientsOne,
                                                                              double[] arrayOfCoefficientsTwo,
                                                                              double[] arrayOfCoefficientsExpected)
        {
            Polynomial polynomialOne = new Polynomial(arrayOfCoefficientsOne);
            Polynomial polynomialTwo = new Polynomial(arrayOfCoefficientsTwo);
            Polynomial expected = new Polynomial(arrayOfCoefficientsExpected);
            Polynomial actual = polynomialOne + polynomialTwo;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 3, 3 }, new double[] { 0, -1, 0 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 3, 3 }, new double[] { -1, -3, -2 })]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 4 }, new double[] { 0, 0, -1 })]
        public void OperatorMinus_PolynomialSubtraction_ShouldBeCalculatedCorrectly(double[] arrayOfCoefficientsOne,
                                                                                    double[] arrayOfCoefficientsTwo,
                                                                                    double[] arrayOfCoefficientsExpected)
        {
            Polynomial polynomialOne = new Polynomial(arrayOfCoefficientsOne);
            Polynomial polynomialTwo = new Polynomial(arrayOfCoefficientsTwo);
            Polynomial expected = new Polynomial(arrayOfCoefficientsExpected);
            Polynomial actual = polynomialOne - polynomialTwo;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new double[] { 2, -3 }, new double[] { 1, -7, 1 }, new double[] { 2, -17, 23, -3 })]
        [TestCase(new double[] { -1, 1 }, new double[] { -1, 2, 1 }, new double[] { 1, -3, 1, 1 })]
        [TestCase(new double[] { 3, 5, 2, 1 }, new double[] { 2, 8, 1 }, new double[] { 6, 34, 47, 23, 10, 1 })]
        public void OperatorMultiplication_PolynomialMultiplication_ShouldBeCalculatedCorrectly(double[] arrayOfCoefficientsOne,
                                                                                                double[] arrayOfCoefficientsTwo,
                                                                                                double[] arrayOfCoefficientsExpected)
        {
            Polynomial polynomialOne = new Polynomial(arrayOfCoefficientsOne);
            Polynomial polynomialTwo = new Polynomial(arrayOfCoefficientsTwo);
            Polynomial expected = new Polynomial(arrayOfCoefficientsExpected);
            Polynomial actual = polynomialOne * polynomialTwo;
            Assert.AreEqual(expected, actual);
        }
    }
}
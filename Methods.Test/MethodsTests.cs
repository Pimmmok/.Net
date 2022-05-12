using NUnit.Framework;
using System;

namespace _3._Methods.Tests
{
    public class MethodsTests
    {
        [TestCase(57772, 5252, ExpectedResult = 5252)]
        [TestCase(12353, 5423, ExpectedResult = 11)]
        [TestCase(0, -1, ExpectedResult = 1)]
        public int EuclidsAlgorithmToCalculate_CalculateTwoNumbers_ShouldBeCalculatedCorrectly(int numberOne, int numberTwo)
        {
            
            return CalculatorNod.CalculateEuclidsAlgorithm(numberOne, numberTwo);
        }

        [TestCase(57772, 5252, default, ExpectedResult = 5252)]
        [TestCase(12353, 5423, default, ExpectedResult = 11)]
        [TestCase(0, -1, default, ExpectedResult = 1)]
        public int EuclidsAlgorithmToCalculate_CalculateTwoNumbersAndTime_ShouldBeCalculatedCorrectly(int numberOne, int numberTwo, out TimeSpan time)
        {
            return CalculatorNod.CalculateEuclidsAlgorithm(numberOne, numberTwo, out time);
        }

        [TestCase(57772, 5252, 10504, ExpectedResult = 5252)]
        [TestCase(12353, 5423, 33, ExpectedResult = 11)]
        [TestCase(0, -1, 0, ExpectedResult = 1)]
        public int EuclidsAlgorithmToCalculate_CalculateThreeNumbers_ShouldBeCalculatedCorrectly(int numberOne, int numberTwo, int numberThree)
        {
            return CalculatorNod.CalculateEuclidsAlgorithm(numberOne, numberTwo, numberThree);
        }

        [TestCase(57772, 5252, 10504, 15756, ExpectedResult = 5252)]
        [TestCase(12353, 5423, 33, 16269, ExpectedResult = 11)]
        [TestCase(0, -1, 0, 1, ExpectedResult = 1)]
        public int EuclidsAlgorithmToCalculate_CalculateFourNumbers_ShouldBeCalculatedCorrectly(int numberOne,
                                                                                                int numberTwo,
                                                                                                int numberThree,
                                                                                                int numberFour)
        {
            
            return CalculatorNod.CalculateEuclidsAlgorithm(numberOne, numberTwo, numberThree, numberFour);
        }

        [TestCase(57772, 5252, 10504, 15756, 21008, ExpectedResult = 5252)]
        [TestCase(12353, 5423, 33, 16269, 1089, ExpectedResult = 11)]
        [TestCase(0, 1, 0, 1, -1, ExpectedResult = 1)]
        public int EuclidsAlgorithmToCalculate_CalculateFiveNumbers_ShouldBeCalculatedCorrectly(int numberOne,
                                                                                                int numberTwo,
                                                                                                int numberThree,
                                                                                                int numberFour,
                                                                                                int numberFive)
        {
            return CalculatorNod.CalculateEuclidsAlgorithm(numberOne, numberTwo, numberThree, numberFour, numberFive);
         }

        [TestCase(57772, 5252, ExpectedResult = 5252)]
        [TestCase(12353, 5423, ExpectedResult = 11)]
        [TestCase(0, -1, ExpectedResult = 1)]
        public int CalculateSteinAlgorithm__CalculateTwoNumbers_ShouldBeCalculatedCorrectly(int numberOne, int numberTwo)
        {
            return CalculatorNod.CalculateSteinAlgorithm(numberOne, numberTwo);
        }

        [TestCase(57772, 5252, default, ExpectedResult = 5252)]
        [TestCase(12353, 5423, default, ExpectedResult = 11)]
        [TestCase(0, -1, default, ExpectedResult = 1)]
        public int CalculateSteinAlgorithm__CalculateTwoNumbersAndTime_ShouldBeCalculatedCorrectly(int numberOne,
                                                                                               int numberTwo,
                                                                                               out TimeSpan time)
        {
            return CalculatorNod.CalculateSteinAlgorithm(numberOne, numberTwo, out time);
        }
    }
}
using System;
using System.Diagnostics;

namespace _3._Methods
{
    public static class CalculatorNod
    {
        public static int CalculateEuclidsAlgorithm(int numberOne, int numberTwo)
        {
            numberOne = Math.Abs(numberOne);
            numberTwo = Math.Abs(numberTwo);
            if (numberOne == numberTwo)
            {
                return numberOne;
            }
            if (numberOne == 0)
            {
                return numberTwo;
            }
            if (numberTwo == 0)
            {
                return numberOne;
            }
            while (numberOne != 0 && numberTwo != 0)
            {
                if (numberOne > numberTwo)
                {
                    numberOne %= numberTwo;
                }
                else
                {
                    numberTwo %= numberOne;
                }
            }
            return numberOne + numberTwo;
        }

        public static int CalculateEuclidsAlgorithm(int numberOne, int numberTwo, int numberThree)
        {
            return CalculateEuclidsAlgorithm(CalculateEuclidsAlgorithm(numberOne,
                                                                             numberTwo), numberThree);
        }

        public static int CalculateEuclidsAlgorithm(int numberOne, int numberTwo, int numberThree, int numberFour)
        {
            return CalculateEuclidsAlgorithm(CalculateEuclidsAlgorithm(numberOne,
                                                                           numberTwo,
                                                                           numberThree), numberFour);
        }
        public static int CalculateEuclidsAlgorithm(int numberOne, int numberTwo, int numberThree, int numberFour, int numberFive)
        {
            return CalculateEuclidsAlgorithm(CalculateEuclidsAlgorithm(numberOne,
                                                                           numberTwo,
                                                                           numberThree, numberFour), numberFive);
        }

        public static int CalculateEuclidsAlgorithm(int numberOne, int numberTwo, out TimeSpan time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = CalculateEuclidsAlgorithm(numberOne, numberTwo);
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            return result;
        }

        public static int CalculateSteinAlgorithm(int numberOne, int numberTwo)
        {
            numberOne = Math.Abs(numberOne);
            numberTwo = Math.Abs(numberTwo);
            if (numberOne == numberTwo)
            {
                return numberOne;
            }
            if (numberOne == 0)
            {
                return numberTwo;
            }
            if (numberTwo == 0)
            {
                return numberOne;
            }
            bool numberOneIsEven = (numberOne & 1) == 0;
            bool numberTwoIsEven = (numberTwo & 1) == 0;
            if (numberOneIsEven && numberTwoIsEven)
            {
                return CalculateSteinAlgorithm(numberOne >> 1, numberTwo >> 1) << 1;
            }
            else if (numberOneIsEven && !numberTwoIsEven)
            {
                return CalculateSteinAlgorithm(numberOne >> 1, numberTwo);
            }
            else if (numberTwoIsEven)
            {
                return CalculateSteinAlgorithm(numberOne, numberTwo >> 1);
            }
            else
            {
                return numberOne > numberTwo
                ? CalculateSteinAlgorithm((numberOne - numberTwo) >> 1, numberTwo)
                : CalculateSteinAlgorithm(numberOne, (numberTwo - numberOne) >> 1);
            }

        }

        public static int CalculateSteinAlgorithm(int numberOne, int numberTwo, out TimeSpan time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = CalculateSteinAlgorithm(numberOne, numberTwo);
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            return result;
        }
    }
}

using System;
namespace Basic_programming_constructions
{
    public static class NewtonMethod
    {
        public static double FindSqrtNewton(double number,
                                        int degree,
                                        ref double accuracy)
        {
            if (accuracy >= 1 || accuracy <= -1)
            {
                accuracy = 0.0001;
            }

            if (degree < -1 && number < 0)
            {
                return double.NaN;
            }

            if (degree % 2 == 0 && number < 0)
            {
                return double.NaN;
            }
            else
            {
                if (degree < 0)
                {
                    number = 1.0 / number;
                    degree = Math.Abs(degree);
                }
                double result = number;
                double approximateNumber = 0;
                while (Math.Abs(approximateNumber - result) >= accuracy)
                {
                    double tempValue = number;
                    for (int i = 1; i < degree; i++)
                    {
                        tempValue /= result;
                    }
                    approximateNumber = result;
                    result = 1.0 / degree * (((degree - 1) * result) + tempValue);
                }
                return result;
            }
        }
        public static double CompareWithStandardFunction(double result, double number, int degree, out double difference)
        {
            double resultStandardFunction = Math.Pow(number, 1.0 / degree);
            difference = Math.Abs(result - resultStandardFunction) / result * 100;
            return resultStandardFunction;
        }
    }
}


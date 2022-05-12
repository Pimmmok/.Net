using System;
using System.Linq;
using System.Text;

namespace _2._2_Basic_programming_constructions
{
    public static class BinaryConversionClass
    {
        public static string СonvertByBinaryMethod(uint number)
        {
            StringBuilder result = new StringBuilder();
            do
            {
                result = result.Append(number % 2);
                number /= 2;
            }
            while (number != 0);
            return new string(result.ToString().ToCharArray().Reverse().ToArray());
        }
    }
}

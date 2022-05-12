using System;

namespace _2._2_Basic_programming_constructions
{
    class Program
    {
        static void Main()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Console.WriteLine("Сonvert to binary");
                do
                {
                    Console.Write("Enter number (An integer in the range up to 4294967295):");

                    if (!uint.TryParse(Console.ReadLine().ToString(), out uint number))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    Console.WriteLine(BinaryConversionClass.СonvertByBinaryMethod(number));
                    Console.WriteLine("To enter a new value, press any key, to exit - Q");
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Q);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}




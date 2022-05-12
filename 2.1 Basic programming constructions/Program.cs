using System;

namespace Basic_programming_constructions
{
    class Program
    {

        static void Main()
        {
            double _result = 0;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine("Calculating x^(1/y)");
            while (true)
            {
                try
                {
                    Console.Write("Enter number:");
                    if (!double.TryParse(Console.ReadLine().ToString(), out double number))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    Console.Write("Enter degree (An integer in the range from -2147483648 to 2147483647):");
                    if (!int.TryParse(Console.ReadLine().ToString(), out int degree))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    Console.Write("Enter calculation accuracy (format:0.XXXXXXXXXX, if >1 or <-1 accuracy=0.0001):");
                    if (!double.TryParse(Console.ReadLine().ToString(), out double accuracy))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    bool done = true;
                    while (done)
                    {
                        Console.WriteLine("Choose a method of calculating x^(1/y):");
                        Console.WriteLine("1. Сalculating the root of the n-power by the Newton method (enter <1>)");
                        Console.WriteLine("2. Comparison by calculating the root of the n-power using the standard library method (enter <2>)");
                        Console.WriteLine("Enter <N> to enter new data. Enter <Q> to exit.");
                        bool calculationWasMade = false;
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                {
                                    _result = NewtonMethod.FindSqrtNewton(number, degree, ref accuracy);
                                    Console.WriteLine("The root of the n-power by the Newton method: "
                                                      + _result.ToString()
                                                      + " with accuracy "
                                                      + accuracy.ToString());
                                    calculationWasMade = true;
                                }
                                break;

                            case '2':
                                {
                                    if (calculationWasMade == false)
                                    {
                                        _result = NewtonMethod.FindSqrtNewton(number, degree, ref accuracy);
                                    }
                                    Console.WriteLine(" Comparison by calculating the root of the n-power using the standard library method:");
                                    Console.WriteLine("Newton method: " + _result.ToString() + " with accuracy " + accuracy.ToString() +
                                        " , standard library method: " + NewtonMethod.CompareWithStandardFunction(_result, number, degree, out double difference).ToString() +
                                        " , relative difference %: " + difference.ToString("f4"));
                                }
                                break;

                            case 'n':
                                done = false;
                                _result = 0;
                                break;

                            case 'q':
                                Environment.Exit(0);
                                break;

                            default:
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}



using System;

namespace _4_Creating_of_new_type
{
    class Program
    {
        static void Main()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Triangle triangle;
                Console.WriteLine("Triangle");
                while (true)
                {
                    Console.Write("Enter side one:");
                    if (!double.TryParse(Console.ReadLine().ToString(), out double sideOne))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    Console.Write("Enter side two:");
                    if (!double.TryParse(Console.ReadLine().ToString(), out double sideTwo))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    Console.Write("Enter side three:");
                    if (!double.TryParse(Console.ReadLine().ToString(), out double sideThree))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    triangle = new Triangle(sideOne, sideTwo, sideThree);
                    Console.Write("Created: " + triangle.ToString() + "\n");
                    if (!triangle.Exists())
                    {
                        Console.WriteLine("Object is not a triangle");
                        continue;
                    }
                    break;
                };
                while (true)
                {
                    Console.WriteLine("What should be done?:");
                    Console.WriteLine("1. Сalculate perimeter(enter <1>)");
                    Console.WriteLine("2. Calculate area (enter <2>)");
                    Console.WriteLine("3. Сhange object (enter <3>)");
                    Console.WriteLine("Enter <Q> to exit");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            {
                                Console.WriteLine("Perimeter: " + triangle.СalculatePerimeter().ToString());
                            }
                            break;

                        case '2':
                            {
                                Console.WriteLine("Area: " + triangle.СalculateArea().ToString("f3"));
                            }
                            break;

                        case '3':
                            {
                                while (true)
                                {
                                    Console.Write("Enter side one:");
                                    if (!double.TryParse(Console.ReadLine().ToString(), out double sideOne))
                                    {
                                        Console.WriteLine("Invalid format, please input again!");
                                        continue;
                                    }
                                    Console.Write("Enter side two:");
                                    if (!double.TryParse(Console.ReadLine().ToString(), out double sideTwo))
                                    {
                                        Console.WriteLine("Invalid format, please input again!");
                                        continue;
                                    }
                                    Console.Write("Enter side three:");
                                    if (!double.TryParse(Console.ReadLine().ToString(), out double sideThree))
                                    {
                                        Console.WriteLine("Invalid format, please input again!");
                                        continue;
                                    }
                                    triangle.SetSide(sideOne, sideTwo, sideThree);
                                    Console.Write("Object changed to: " + triangle.ToString() + "\n");
                                    if (!triangle.Exists())
                                    {
                                        Console.WriteLine("Object is not a triangle");
                                        continue;
                                    }
                                    break;
                                }
                                break;
                            }
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
                throw;
            }
        }
    }
}

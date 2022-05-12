using System;

namespace _5._2_Incapsulation_and_overriding
{
    class Program
    {
        private static void EnterToData(Polynomial[] polynomials)
        {
            int i = 1;
            do
            {
                Console.Write("Enter degree of polynomial " + i.ToString() + " (positive integer):");
                if (!uint.TryParse(Console.ReadLine(), out uint degree))
                {
                    Console.WriteLine("Invalid format, please input again!");
                    continue;
                }
                double[] polynomialInput = new double[degree + 1];
                while (true)
                {
                    Console.WriteLine("Please enter polynomial " + i.ToString() + " сoefficients "
                        + "in the format: a,n (for formula aX^n, n>0). Enter <C/c> to complete data entry");
                    string[] polynomialStringInput = Console.ReadLine().Split(',');
                    if (polynomialStringInput[0] == "c" || polynomialStringInput[0] == "C")
                    {
                        if (polynomialInput[degree] != 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The coefficient for the degree of the polynomial is not set, please input again!");
                            continue;
                        }
                    }
                    if (polynomialStringInput.Length < 2)
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    if (!uint.TryParse(polynomialStringInput[1], out uint degreeInput))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    if (degreeInput > degree)
                    {
                        Console.WriteLine("Invalid degree!, please input again!");
                        continue;
                    }
                    if (!double.TryParse(polynomialStringInput[0], out double сoefficientInput))
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    polynomialInput[degreeInput] = сoefficientInput;
                }
                polynomials[i - 1] = new Polynomial(polynomialInput);
                i++;
            }
            while (i < 3);
            Console.WriteLine("Polynomials in work:");
            foreach (Polynomial polynomial in polynomials)
            {
                Console.WriteLine(polynomial);
            }
        }

        static void Main()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Console.WriteLine("Polynomial");
                Polynomial[] polynomials = new Polynomial[2];
                EnterToData(polynomials);
                while (true)
                {
                    Console.WriteLine("What should be done?:");
                    Console.WriteLine("1. Сalculate summa (enter <1>)");
                    Console.WriteLine("2. Calculate difference (enter <2>)");
                    Console.WriteLine("3. Calculate multiplication (enter <3>)");
                    Console.WriteLine("4. Сompare polynomials (enter <4>)");
                    Console.WriteLine("5. Enter new polynomials (enter <5>)");
                    Console.WriteLine("Enter <Q> to exit");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            {
                                Console.WriteLine(polynomials[0] + " + \n" + polynomials[1] + " = \n " + (polynomials[0] + polynomials[1]));
                            }
                            break;

                        case '2':
                            {
                                Console.WriteLine(polynomials[0] + " - \n" + polynomials[1] + " = \n " + (polynomials[0] - polynomials[1]));
                            }
                            break;

                        case '3':
                            {
                                Console.WriteLine(polynomials[0] + " * \n" + polynomials[1] + " = \n " + (polynomials[0] * polynomials[1]));
                            }
                            break;

                        case '4':
                            {
                                if (polynomials[0] == polynomials[1])
                                {
                                    Console.WriteLine("Polynomial " + polynomials[0] + " equals polynomial " + polynomials[1]);
                                }
                                else
                                {
                                    Console.WriteLine("Polynomial " + polynomials[0] + " is not equal to polynomial " + polynomials[1]);
                                }
                            }
                            break;

                        case '5':
                            {
                                EnterToData(polynomials);
                            }
                            break;


                        case 'q':
                            return;
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

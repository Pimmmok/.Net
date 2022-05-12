using System;

namespace _5._1_Incapsulation_and_overriding
{
    class Program
    {
        static void Main()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Vector[] vectors = new Vector[2];
                Console.WriteLine("Vektor");
                int i = 1;
                do
                {
                    Console.WriteLine("Please enter vector " + i.ToString() + " in the format: <Name>(X,Y,Z)");
                    string[] vectorInput = Console.ReadLine().Split('(');
                    if (vectorInput.Length < 2)
                    {
                        Console.WriteLine("Invalid format, please input again!");
                        continue;
                    }
                    string[] vectorCoordinates = vectorInput[1].Split(',');
                    if (vectorCoordinates.Length == 3
                        && double.TryParse(vectorCoordinates[0], out double X)
                        && double.TryParse(vectorCoordinates[1], out double Y)
                        && double.TryParse(vectorCoordinates[2].Replace(")", ""), out double Z))
                    {
                        vectors[i - 1] = new Vector(vectorInput[0], X, Y, Z);
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid format, please input again!");
                    }
                }
                while (i < 3);
                Console.WriteLine("Vektors in work:");
                foreach (Vector vector in vectors)
                {
                    Console.WriteLine(vector);
                }
                while (true)
                {
                    Console.WriteLine("What should be done?:");
                    Console.WriteLine("1. Сalculate summa (enter <1>)");
                    Console.WriteLine("2. Calculate difference (enter <2>)");
                    Console.WriteLine("3. Calculate vector multiplication (enter <3>)");
                    Console.WriteLine("4. Calculate scalar multiplication (enter <4>)");
                    Console.WriteLine("5. Сalculate length of vectors (enter <5>)");
                    Console.WriteLine("6. Сalculate angle between vectors (enter <6>)");
                    Console.WriteLine("7. Сompare vectors(enter <7>)");
                    Console.WriteLine("8. Сhange vectors (enter <8>)");
                    Console.WriteLine("Enter <Q> to exit");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            {
                                Console.WriteLine(vectors[0] + vectors[1]);
                            }
                            break;

                        case '2':
                            {
                                Console.WriteLine(vectors[0] - vectors[1]);
                            }
                            break;

                        case '3':
                            {
                                Console.WriteLine(vectors[0] * vectors[1]);
                            }
                            break;
                        case '4':
                            {
                                Console.WriteLine("Scalar multiplication: " + vectors[0].CalculateScalarMultiplication(vectors[1]).ToString("f4"));
                            }
                            break;
                        case '5':
                            {
                                Console.WriteLine(vectors[0] + " length: " + vectors[0].CalculateLength().ToString("f4"));
                                Console.WriteLine(vectors[1] + " length: " + vectors[1].CalculateLength().ToString("f4"));
                            }
                            break;


                        case '6':
                            {
                                Console.WriteLine("Angle between vectors: "
                                                  + vectors[0].CalculateAngleBetweenVectors(vectors[1]).ToString("f4")
                                                  + " degree");
                            }
                            break;

                        case '7':
                            {
                                if (vectors[0] == vectors[1])
                                {
                                    Console.WriteLine(vectors[0] + " equals " + vectors[1] );
                                }
                                else
                                {
                                    Console.WriteLine(vectors[0] + " is not equal to " + vectors[1]);
                                }
                            }
                            break;

                        case '8':
                            {
                                while (true)
                                {
                                    i = 1;
                                    do
                                    {
                                        Console.WriteLine("Please change vector " + vectors[i - 1].Name +  " in the format: <Name>(X,Y,Z)");
                                        string[] vectorInput = Console.ReadLine().Split('(');
                                        if (vectorInput.Length < 2)
                                        {
                                            Console.WriteLine("Invalid format, please input again!");
                                            continue;
                                        }
                                        string[] vectorCoordinates = vectorInput[1].Split(',');
                                        if (vectorCoordinates.Length == 3
                                            && double.TryParse(vectorCoordinates[0], out double X)
                                            && double.TryParse(vectorCoordinates[1], out double Y)
                                            && double.TryParse(vectorCoordinates[2].Replace(")", ""), out double Z))
                                        {
                                            vectors[i - 1].Name = vectorInput[0];
                                            vectors[i - 1].X = X;
                                            vectors[i - 1].Y = Y;
                                            vectors[i - 1].Z = Z;
                                            i++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid format, please input again!");
                                        }
                                    }
                                    while (i < 3);
                                    Console.WriteLine("Modified vectors in work:");
                                    foreach (Vector vector in vectors)
                                    {
                                        Console.WriteLine(vector);
                                    }
                                    break;
                                }
                            }
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
                throw;
            }
        }
    }
}


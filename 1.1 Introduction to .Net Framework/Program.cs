using System;

namespace Introduction_to_.Net_Framework
{
    class Program
    {

        /// <summary>
        /// Сonsole I / O.
        /// </summary>
        static void Main()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                while (true)
                {
                    Console.WriteLine("Choose a method of data processing:");
                    Console.WriteLine("1. From Console to Console (enter <1>)");
                    Console.WriteLine("2. From File <data.txt> to Console (enter <2>)");
                    Console.WriteLine("3. From Console to File <data.txt> (enter <3>)");
                    Console.WriteLine("4. From File <data.txt> to File <data.txt> (enter <4>)");
                    Console.WriteLine("Enter <Q> to exit");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            {
                                Context<Coordinate> context = new Context<Coordinate>(new ConsoleCoordinateReader(), new ConsoleCoordinateWriter());
                                context.ExecuteDataProcessing();
                                break;
                            }
                        case '2':
                            {
                                Context<Coordinate> context = new Context<Coordinate>(new FileCoordinateReader(), new ConsoleCoordinateWriter());
                                context.ExecuteDataProcessing();
                            }
                            break;
                        case '3':
                            {
                                Context<Coordinate> context = new Context<Coordinate>(new ConsoleCoordinateReader(), new FileCoordinateWriter());
                                context.ExecuteDataProcessing();
                                break;
                            }

                        case '4':
                            {
                                Context<Coordinate> context = new Context<Coordinate>(new FileCoordinateReader(), new FileCoordinateWriter());
                                context.ExecuteDataProcessing();
                                break;
                            }
                        case 'q':
                            Environment.Exit(0);
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


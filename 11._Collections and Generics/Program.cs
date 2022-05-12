using System;

namespace _11._Collections_and_Generics
{
    class Program
    {
        static void Main()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Console.WriteLine("Student Test Results");
                BynaryTree<TestStudent> tree = new BynaryTree<TestStudent>(null);
                Console.WriteLine("Input of initial data:");
                Console.WriteLine("1.Enter data manually. Enter <1>");
                Console.WriteLine("2.Testing the application based on test data. Enter <2>");
                Console.WriteLine("Enter <Q> to exit");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        {
                            int numberOfTestResults = 0;
                            while (true)
                            {
                                Console.WriteLine("Please enter test results # " + numberOfTestResults.ToString());
                                Console.WriteLine("Enter name:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter surname:");
                                string surname = Console.ReadLine();
                                Console.WriteLine("Enter test name:");
                                string testName = Console.ReadLine();
                                DateTime testDate;
                                int testResult;
                                while (true)
                                {
                                    Console.WriteLine("Enter test date in format {month / day / year}:");
                                    string dateRead = Console.ReadLine();
                                    if (DateTime.TryParse(dateRead, out DateTime testDateRead))
                                    {
                                        testDate = testDateRead;
                                        break;
                                    }
                                    Console.WriteLine("Invalid format, please input again!");
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter test result:");
                                    if (int.TryParse(Console.ReadLine(), out int testResultRead))
                                    {
                                        testResult = testResultRead;
                                        break;
                                    }
                                    Console.WriteLine("Invalid format, please input again!");
                                }
                                tree.Insert(new TestStudent(name, surname, testName, testDate, testResult));
                                numberOfTestResults++;
                                Console.WriteLine("To finish entering test results, press <C>, to continue entering results, "
                                    + "press any other key:");
                                if (Console.ReadKey(true).Key == ConsoleKey.C)
                                {
                                    break;
                                }
                            }
                            Console.WriteLine("=========Student Test Results (data manually)=====================");
                            foreach (TestStudent testStudent in tree)
                            {
                                Console.WriteLine(testStudent);
                            }
                        }
                        break;

                    case '2':
                        {

                            tree.Insert(new TestStudent("Serj", "Sidirow", "c#", new DateTime(2021, 12, 7), 10));
                            tree.Insert(new TestStudent("Serj", "Sidirow", "c++", new DateTime(2021, 12, 7), 7));
                            tree.Insert(new TestStudent("Ivan", "Ivanov", "c#", new DateTime(2021, 12, 7), 3));
                            tree.Insert(new TestStudent("Ivan", "Ivanov", "c++", new DateTime(2021, 12, 7), 2));
                            tree.Insert(new TestStudent("Alex", "Low", "c#", new DateTime(2021, 12, 7), 7));
                            tree.Insert(new TestStudent("Alex", "Low", "c++", new DateTime(2021, 12, 7), 6));
                            tree.Insert(new TestStudent("Vlad", "Vladow", "c#", new DateTime(2021, 12, 7), 8));
                            tree.Insert(new TestStudent("Vlad", "Vladow", "c++", new DateTime(2021, 12, 5), 9));
                            tree.Insert(new TestStudent("Ben", "Benow", "c++", new DateTime(2021, 12, 5), 9));
                            tree.Insert(new TestStudent("Ben", "Benow", "c#", new DateTime(2021, 12, 7), 10));
                            Console.WriteLine("=========Student Test Results (test data)======================");
                            foreach (TestStudent testStudent in tree)
                            {
                                Console.WriteLine(testStudent);
                            }
                        }
                        break;

                    case 'Q':
                        {
                            return;
                        }

                    default:
                        break;
                }
            }

            catch (ResultStudentTestException ex)
            {
                Console.WriteLine("Message: " + ex.Message + " Test result: " + ex.IncorrectResult.ToString() + " - not allowed!");
                throw;
            }

            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred. Type: " + ex.GetType().FullName + " Message: " + ex.Message);
                throw;
            }
        }
    }
}


using System;
using System.Collections.Generic;
using _11._Collections_and_Generics;

namespace _12._Linq
{
    internal class Program
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine("Student Test Results (LINQ)");
            ITestHandler testHandler = new TestHandler();
            testHandler.InsertTestResult(new TestStudent("Serj", "Sidirow", "c#", new DateTime(2021, 12, 7), 10));
            testHandler.InsertTestResult(new TestStudent("Serj", "Sidirow", "c++", new DateTime(2021, 12, 7), 7));
            testHandler.InsertTestResult(new TestStudent("Ivan", "Ivanov", "c#", new DateTime(2021, 12, 7), 3));
            testHandler.InsertTestResult(new TestStudent("Ivan", "Ivanov", "c++", new DateTime(2021, 12, 7), 5));
            testHandler.InsertTestResult(new TestStudent("Vlad", "Vladow", "c#", new DateTime(2021, 12, 7), 8));
            testHandler.InsertTestResult(new TestStudent("Vlad", "Vladow", "c++", new DateTime(2021, 12, 5), 9));
            testHandler.SaveTestResultsToFile("TestStudent.dat");
            Console.WriteLine("Initial data loaded and saved in file: <TestStudent.dat>");
            Console.WriteLine("=========Student Test Results=====================");
            foreach (TestStudent testStudent in testHandler.GetTestStudent())
            {
                Console.WriteLine(testStudent);
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("0.Add data about test results. Enter <0>");
                    Console.WriteLine("1.Save data to file <TestStudent.dat>. Enter <1>");
                    Console.WriteLine("2.Read data from file <TestStudent.dat>. Enter <2>");
                    Console.WriteLine("3.Display test results for a test name. Enter <3>");
                    Console.WriteLine("4.Display test results for a test name ... with a score greater than .... Enter <4>");
                    Console.WriteLine("5.Display avverage test results for a test name ... Enter <5>");
                    Console.WriteLine("6.Display test results for a surname. Enter <6>");
                    Console.WriteLine("7.Display test results for a test surname ... with a score greater than .... Enter <7>");
                    Console.WriteLine("8.Display avverage test results for a surname ... Enter <8>");
                    Console.WriteLine("9.Display test results test for the date ... Enter <9>");
                    Console.WriteLine("Enter <Q> to exit");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '0':
                            {
                                while (true)
                                {
                                    Console.WriteLine($"You have selected an item 0. Please enter test results.");
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
                                        if (DateTime.TryParse(Console.ReadLine(), out DateTime testDateRead))
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
                                    testHandler.InsertTestResult(new TestStudent(name, surname, testName, testDate, testResult));
                                    Console.WriteLine("To finish entering test results, press <C>, to continue entering results, press any other key:");
                                    if (Console.ReadKey(true).Key == ConsoleKey.C)
                                    {
                                        break;
                                    }
                                }
                                Console.WriteLine("=========Student Test Results=====================");
                                foreach (TestStudent testStudent in testHandler.GetTestStudent())
                                {
                                    Console.WriteLine(testStudent);
                                }
                            }
                            break;

                        case '1':
                            {
                                Console.WriteLine($"You have selected an item 1.");
                                testHandler.SaveTestResultsToFile("TestStudent.dat");
                                Console.WriteLine("Objects serialized to file <TestStudent.dat>");
                            }
                            break;

                        case '2':
                            {
                                Console.WriteLine($"You have selected an item 2.");
                                testHandler.LoadTestResultsFromFile("TestStudent.dat");
                                Console.WriteLine("=========Student Test Results (read from file <TestStudent.dat>)======================");
                                foreach (TestStudent testStudent in testHandler.GetTestStudent())
                                {
                                    Console.WriteLine(testStudent);
                                }
                            }
                            break;
                        case '3':
                            {
                                Console.WriteLine($"You have selected an item 3.");
                                Console.WriteLine("Enter test name:");
                                string testNameRead = Console.ReadLine();
                                Console.WriteLine("Enter maximum number of lines to display information:");
                                if (!int.TryParse(Console.ReadLine(), out int maxRows))
                                {
                                    Console.WriteLine("Invalid format, please input again!");
                                    break;
                                }
                                Console.WriteLine("Enter 1 to sort directly by last name, press 2 to sort backward by last name. " +
                                    "Enter any character to keep natural sorting.");
                                char option = Console.ReadKey(true).KeyChar;
                                Console.WriteLine("============Results test < " + testNameRead + ">  =======");
                                if (option.Equals('1'))
                                {
                                    testHandler.SelectResultsByTestName(testNameRead,
                                                                        out IEnumerable<TestStudent> selectedTest,
                                                                        maxRows,
                                                                        Sorting.anscending);
                                    foreach (TestStudent test in selectedTest)
                                    {
                                        Console.WriteLine($"{test}");
                                    }
                                }
                                if (option.Equals('2'))
                                {
                                    testHandler.SelectResultsByTestName(testNameRead,
                                                                        out IEnumerable<TestStudent> selectedTest,
                                                                        maxRows,
                                                                        Sorting.descending);
                                    foreach (TestStudent test in selectedTest)
                                    {
                                        Console.WriteLine($"{test}");
                                    }
                                }
                                if (!option.Equals('1') && !option.Equals('2'))
                                {
                                    testHandler.SelectResultsByTestName(testNameRead, out IEnumerable<TestStudent> selectedTest, maxRows);
                                    foreach (TestStudent test in selectedTest)
                                    {
                                        Console.WriteLine($"{test}");
                                    }
                                }
                            }
                            break;

                        case '4':
                            {
                                Console.WriteLine($"You have selected an item 4.");
                                Console.WriteLine("Enter test name:");
                                string testNameRead = Console.ReadLine();
                                Console.WriteLine("Enter min test result: ");
                                if (!int.TryParse(Console.ReadLine(), out int minTestResultRead))
                                {
                                    Console.WriteLine("Invalid format, please input again!");
                                    break;
                                }
                                Console.WriteLine("Enter maximum number of lines to display information:");
                                if (!int.TryParse(Console.ReadLine(), out int maxRows))
                                {
                                    Console.WriteLine("Invalid format, please input again!");
                                    break;
                                }
                                Console.WriteLine("============Test < " + testNameRead + " >  Results >= " + minTestResultRead + "=======");
                                testHandler.SelectResultsByTestName(testNameRead,
                                                                    out IEnumerable<TestStudent> selectedTest,
                                                                    maxRows,
                                                                    Sorting.no,
                                                                    minTestResultRead);
                                foreach (TestStudent test in selectedTest)
                                {
                                    Console.WriteLine($"{test}");
                                }
                            }
                            break;

                        case '5':
                            {
                                Console.WriteLine($"You have selected an item 5.");
                                Console.WriteLine("Enter test name:");
                                string testNameRead = Console.ReadLine();
                                Console.WriteLine("===Test < " + testNameRead + " > average: " +
                                    testHandler.GetAvverageResultsForTestName(testNameRead).ToString());
                            }
                            break;

                        case '6':
                            {
                                Console.WriteLine($"You have selected an item 6.");
                                Console.WriteLine("Enter  surname:");
                                string surnameRead = Console.ReadLine();
                                Console.WriteLine("Enter maximum number of lines to display information:");
                                if (!int.TryParse(Console.ReadLine(), out int maxRows))
                                {
                                    Console.WriteLine("Invalid format, please input again!");
                                    break;
                                }
                                Console.WriteLine("Enter 1 to sort directly by test name, press 2 to sort backward by test name. " +
                                    "Enter any character to keep natural sorting.");
                                char option = Console.ReadKey(true).KeyChar;
                                Console.WriteLine("============Results test < " + surnameRead + " >  =======");
                                if (option.Equals('1'))
                                {
                                    testHandler.SelectResultsBySurname(surnameRead,
                                                                       out IEnumerable<TestStudent> selectedTest,
                                                                       maxRows,
                                                                       Sorting.anscending);
                                    foreach (TestStudent test in selectedTest)
                                    {
                                        Console.WriteLine($"{test}");
                                    }
                                }
                                if (option.Equals('2'))
                                {
                                    testHandler.SelectResultsBySurname(surnameRead,
                                                                       out IEnumerable<TestStudent> selectedTest,
                                                                       maxRows,
                                                                       Sorting.descending);
                                    foreach (TestStudent test in selectedTest)
                                    {
                                        Console.WriteLine($"{test}");
                                    }
                                }
                                if (!option.Equals('1') && !option.Equals('2'))
                                {
                                    testHandler.SelectResultsBySurname(surnameRead, out IEnumerable<TestStudent> selectedTest, maxRows);
                                    foreach (TestStudent test in selectedTest)
                                    {
                                        Console.WriteLine($"{test}");
                                    }
                                }
                            }
                            break;

                        case '7':
                            {
                                Console.WriteLine($"You have selected an item 7.");
                                Console.WriteLine("Enter surname:");
                                string surnameRead = Console.ReadLine();
                                Console.WriteLine("Enter min test result: ");
                                if (!int.TryParse(Console.ReadLine(), out int minTestResultRead))
                                {
                                    Console.WriteLine("Invalid format, please input again!");
                                    break;
                                }
                                Console.WriteLine("Enter maximum number of lines to display information:");
                                if (!int.TryParse(Console.ReadLine(), out int maxRows))
                                {
                                    Console.WriteLine("Invalid format, please input again!");
                                    break;
                                }
                                Console.WriteLine("============Test < " + surnameRead + " Results >= " + minTestResultRead.ToString() + "=======");
                                testHandler.SelectResultsBySurname(surnameRead,
                                                                   out IEnumerable<TestStudent> selectedTest,
                                                                   maxRows,
                                                                   Sorting.no,
                                                                   minTestResultRead);
                                foreach (TestStudent test in selectedTest)
                                {
                                    Console.WriteLine($"{test}");
                                }
                            }
                            break;

                        case '8':
                            {
                                Console.WriteLine($"You have selected an item 8.");
                                Console.WriteLine("Enter surname:");
                                string surnameRead = Console.ReadLine();
                                Console.WriteLine("===Test < " + surnameRead + " > average: " +
                                testHandler.GetAvverageResultsForSurname(surnameRead).ToString());
                            }
                            break;

                        case '9':
                            {
                                Console.WriteLine($"You have selected an item 9.");
                                Console.WriteLine("Enter test date in format {month / day /year}:");
                                if (!DateTime.TryParse(Console.ReadLine(), out DateTime testDateRead))
                                {
                                    Console.WriteLine("Invalid format, please input again!");
                                    break;
                                }
                                Console.WriteLine("Enter maximum number of lines to display information:");
                                if (!int.TryParse(Console.ReadLine(), out int maxRows))
                                {
                                    Console.WriteLine("Invalid format, please input again!");
                                    break;
                                }
                                Console.WriteLine("============Results test for the date " + testDateRead.ToString("d") + "=======");
                                testHandler.SelectResultsForDate(testDateRead, out IEnumerable<TestStudent> selectedTest, maxRows);
                                foreach (TestStudent test in selectedTest)
                                {
                                    Console.WriteLine($"{test}");
                                }
                            }
                            break;

                        case 'q':
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
                }

                catch (Exception ex)
                {
                    Console.WriteLine("An exception occurred. Type: " + ex.GetType().FullName + " Message: " + ex.Message);
                }
            }
        }
    }
}


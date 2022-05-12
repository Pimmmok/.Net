using _11._Collections_and_Generics;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace _12._Linq
{
    public class TestHandler: ITestHandler
    {
        private BynaryTree<TestStudent> _tree;
        public IEnumerable<TestStudent> GetTestStudent() { return _tree; }
        private readonly IFileSystem _fileSystem;
        public TestHandler()
        {
            _tree = new BynaryTree<TestStudent>(null);
            _fileSystem = new FileSystem();
        }
        public TestHandler(IFileSystem fileSystem)
        {
            _tree = new BynaryTree<TestStudent>(null);
            _fileSystem = fileSystem;
        }
        public TestHandler(BynaryTree<TestStudent> tree)
        {
            _tree = tree;
            _fileSystem = new FileSystem();
        }

        public void InsertTestResult(TestStudent testStudent)
        {
            _tree.Insert(testStudent);
        }

        public void SaveTestResultsToFile(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using Stream fs = _fileSystem.FileStream.Create(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(fs, _tree);
        }

        public void LoadTestResultsFromFile(string fileName)
        {
            using Stream fs = _fileSystem.FileStream.Create(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            _tree = (BynaryTree<TestStudent>)formatter.Deserialize(fs);
        }

        public void SelectResultsByTestName(string testName,
                                            out IEnumerable<TestStudent> selectedTest,
                                            int maxRows = int.MaxValue,
                                            Sorting sortingForSurname = Sorting.no,
                                            int minResult = 0)
        {
            switch (sortingForSurname)
            {
                case Sorting.anscending:
                    {
                        selectedTest = (from test in _tree
                                        where test.TestName.Equals(testName)
                                        where test.TestResult >= minResult
                                        orderby test.Surname
                                        select test).Take(maxRows);
                    }
                    break;
                case Sorting.descending:
                    {
                        selectedTest = (from test in _tree
                                        where test.TestName.Equals(testName)
                                        where test.TestResult >= minResult
                                        orderby test.Surname descending
                                        select test).Take(maxRows);
                    }
                    break;
                case Sorting.no:
                    {
                        selectedTest = (from test in _tree
                                        where test.TestName.Equals(testName)
                                        where test.TestResult >= minResult
                                        select test).Take(maxRows);
                    }
                    break;
                default:
                    {
                        selectedTest = (from test in _tree
                                        where test.TestName.Equals(testName)
                                        where test.TestResult >= minResult
                                        select test).Take(maxRows);
                    }
                    break;
            }
        }
        public double GetAvverageResultsForTestName(string testName)
        {
            IEnumerable<TestStudent> selectedTest = _tree.Where(t => t.TestName.Equals(testName));
            return selectedTest.Any() ? selectedTest.Average(t => t.TestResult) : double.NaN;
        }

        public void SelectResultsBySurname(string surname,
                                           out IEnumerable<TestStudent> selectedTest,
                                           int maxRows = int.MaxValue,
                                           Sorting sortingForTestName = Sorting.no,
                                           int minResult = 0)
        {
            switch (sortingForTestName)
            {
                case Sorting.anscending:
                    {
                        selectedTest = _tree.Where(t => t.Surname.Equals(surname)).Where(t => t.TestResult >= minResult).
                            OrderBy(t => t.TestName).Take(maxRows);
                    }
                    break;
                case Sorting.descending:
                    {
                        selectedTest = _tree.Where(t => t.Surname.Equals(surname)).Where(t => t.TestResult >= minResult).
                            OrderByDescending(t => t.TestName).Take(maxRows);
                    }
                    break;
                case Sorting.no:
                    {
                        selectedTest = _tree.Where(t => t.Surname.Equals(surname)).Where(t => t.TestResult >= minResult).Take(maxRows);
                    }
                    break;
                default:
                    {
                        selectedTest = _tree.Where(t => t.Surname.Equals(surname)).Where(t => t.TestResult >= minResult).Take(maxRows);
                    }
                    break;
            }
        }
        public double GetAvverageResultsForSurname(string surname)
        {
            IEnumerable<TestStudent> selectedTest = _tree.Where(t => t.Surname.Equals(surname));
            return selectedTest.Any() ? selectedTest.Average(t => t.TestResult) : double.NaN;
        }

        public void SelectResultsForDate(DateTime testDate,
                                          out IEnumerable<TestStudent> selectedTest,
                                          int maxRows = int.MaxValue,
                                          Sorting sortingForTestName = Sorting.no)
        {
            switch (sortingForTestName)
            {
                case Sorting.anscending:
                    {
                        selectedTest = _tree.Where(t => t.TestDate.Equals(testDate)).OrderBy(t => t.TestName).Take(maxRows);
                    }
                    break;
                case Sorting.descending:
                    {
                        selectedTest = _tree.Where(t => t.TestDate.Equals(testDate)).OrderByDescending(t => t.TestName).Take(maxRows);
                    }
                    break;
                case Sorting.no:
                    {
                        selectedTest = _tree.Where(t => t.TestDate.Equals(testDate)).Take(maxRows);
                    }
                    break;
                default:
                    {
                        selectedTest = _tree.Where(t => t.TestDate.Equals(testDate)).Take(maxRows);
                    }
                    break;
            }
        }
    }
}





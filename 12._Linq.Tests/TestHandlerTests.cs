using NUnit.Framework;
using _11._Collections_and_Generics;
using System.Text.Json;
using System.Collections.Generic;
using System;
using _12._Linq.Tests.Properties;
using System.IO.Abstractions.TestingHelpers;

namespace _12._Linq.Tests
{

    public class TestHandlerTests
    {
        private readonly Comparer<object> _comparer = Comparer<object>.Create((a, b) => ((TestStudent)a).TestResult
                                                                                        == ((TestStudent)b).TestResult ? 0 : 1);

        public void ReadCollections(byte[] defaultCollectionsData, out BynaryTree<TestStudent> treeDefault)
        {
            treeDefault = new BynaryTree<TestStudent>(null);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            List<TestStudent> listDefault = JsonSerializer.Deserialize<List<TestStudent>>(defaultCollectionsData, options);
            foreach (TestStudent testStudent in listDefault)
            {
                treeDefault.Insert(testStudent);
            }
        }

        public void ReadCollections(byte[] defaultCollectionsData, byte[] expectedCollectionsData, out BynaryTree<TestStudent> treeDefault,
            out IEnumerable<TestStudent> expected)
        {
            treeDefault = new BynaryTree<TestStudent>(null);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            List<TestStudent> listDefault = JsonSerializer.Deserialize<List<TestStudent>>(defaultCollectionsData, options);
            foreach (TestStudent testStudent in listDefault)
            {
                treeDefault.Insert(testStudent);
            }
            expected = JsonSerializer.Deserialize<List<TestStudent>>(expectedCollectionsData, options);
        }

        [Test]
        public void SelectResultsBySurname_DataSampling_ShouldBeDataCorrectlyAsync()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsBySurname,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsBySurname("Ivanov", out IEnumerable<TestStudent> actual);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsBySurname_DataSamplingAndMaxRow_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsBySurnameAndMaxRow,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsBySurname("Ivanov", out IEnumerable<TestStudent> actual, 1);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsBySurname_DataSamplingAndMaxRowAndAnscendingOrder_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsBySurnameAndMaxRowAndAnscendingOrder,
                            out BynaryTree<TestStudent> treeDefault, out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsBySurname("Ivanov", out IEnumerable<TestStudent> actual, 3, Sorting.anscending);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsBySurname_DataSamplingAndMaxRowAndDescendingOrder_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsBySurnameAndMaxRowAndDescendingOrder, out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsBySurname("Ivanov", out IEnumerable<TestStudent> actual, 3, Sorting.descending);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsBySurname_DataSamplingAndMaxRowAndMinResult_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsBySurnameAndMaxRowAndMinResult,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsBySurname("Ivanov", out IEnumerable<TestStudent> actual, 3, Sorting.no, 10);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsByTestName_DataSampling_ShouldBeDataCorrectlyAsync()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsByTestName,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsByTestName("c#", out IEnumerable<TestStudent> actual);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsByTestName_DataSamplingAndMaxRow_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsByTestNameAndMaxRow,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsByTestName("c#", out IEnumerable<TestStudent> actual, 3);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsByTestName_DataSamplingAndMaxRowAndAnscendingOrder_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsByTestNameAndMaxRowAndAnscendingOrder,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsByTestName("c#", out IEnumerable<TestStudent> actual, 10, Sorting.anscending);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsByTestName_DataSamplingAndMaxRowAndDescendingOrder_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsByTestNameAndMaxRowAndDescendingOrder,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsByTestName("c#", out IEnumerable<TestStudent> actual, 10, Sorting.descending);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SelectResultsByTestName_DataSamplingAndMaxRowAndMinResult_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsBytestNameAndMaxRowAndMinResult,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsByTestName("c#", out IEnumerable<TestStudent> actual, 10, Sorting.no, 7);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [TestCase("c#", 0.001, 6.333)]
        [TestCase("c++", 0.001, 7.4)]
        [TestCase("c###", 0.001, double.NaN)]
        public void GetAvverageResultsForTestName_CalculateAvverage_ShouldBeCalculatedCorrectly(string testName,
                                                                                                double precision,
                                                                                                double expected)
        {
            ReadCollections(Resources.DefaultCollections, out BynaryTree<TestStudent> treeDefault);
            TestHandler testHandler = new TestHandler(treeDefault);
            double actual = testHandler.GetAvverageResultsForTestName(testName);
            Assert.AreEqual(expected, actual, precision);
        }

        [TestCase("Benow", 0.001, 8)]
        [TestCase("Low", 0.001, 5)]
        [TestCase("L", 0.001, double.NaN)]
        public void GetAvverageResultsForSurname_CalculateAvverage_ShouldBeCalculatedCorrectly(string surname,
                                                                                               double precision,
                                                                                               double expected)
        {
            ReadCollections(Resources.DefaultCollections, out BynaryTree<TestStudent> treeDefault);
            TestHandler testHandler = new TestHandler(treeDefault);
            double actual = testHandler.GetAvverageResultsForSurname(surname);
            Assert.AreEqual(expected, actual, precision);
        }

        [Test]
        public void SelectResultsForDate_DataSampling_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.DefaultCollections,
                            Resources.SelectResultsForDate,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.SelectResultsForDate(new DateTime(2021, 12, 5), out IEnumerable<TestStudent> actual);
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }
        [Test]
        public void InsertTestResult_DataSampling_ShouldBeDataCorrectly()
        {
            ReadCollections(Resources.SelectResultsBySurnameAndMaxRow,
                            Resources.InsertTestResult,
                            out BynaryTree<TestStudent> treeDefault,
                            out IEnumerable<TestStudent> expected);
            TestHandler testHandler = new TestHandler(treeDefault);
            testHandler.InsertTestResult(new TestStudent("Ivan", "Ivanov", "c++", new DateTime(2021, 12, 5), 10));
            IEnumerable<TestStudent> actual = testHandler.GetTestStudent();
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        [Test]
        public void SaveTestResultsToFile_DataSampling_ShouldBeDataCorrectly()
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            TestHandler testHandler = new TestHandler(mockFileSystem);
            testHandler.InsertTestResult(new TestStudent("Ivan", "Ivanov", "c#", new DateTime(2021, 12, 7), 9));
            testHandler.InsertTestResult(new TestStudent("Ivan", "Ivanov", "c++", new DateTime(2021, 12, 7), 10));
            string fileName = new string("C:\\temp\\data.txt");
            testHandler.SaveTestResultsToFile(fileName);
            MockFileData mockInputFile = mockFileSystem.GetFile(fileName);
            CollectionAssert.AreEqual(Resources.BynaryFileData, mockInputFile.Contents);
        }
        
        [Test]
        public void LoadTestResultsFromFile_DataSampling_ShouldBeDataCorrectly()
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            string fileName = new string("C:\\temp\\data.dat");
            MockFileData mockInputFile = new MockFileData(Resources.BynaryFileData);
            mockFileSystem.AddFile(fileName, mockInputFile);
            TestHandler actualTestHandler = new TestHandler(mockFileSystem);
            actualTestHandler.LoadTestResultsFromFile(fileName);
            ReadCollections(Resources.SelectResultsBySurname, out BynaryTree<TestStudent> treeExpected);
            CollectionAssert.AreEqual(treeExpected, actualTestHandler.GetTestStudent(), _comparer);
        }
    }
}
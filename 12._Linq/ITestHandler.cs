using _11._Collections_and_Generics;
using System;
using System.Collections.Generic;

namespace _12._Linq
{
    public interface ITestHandler
    {
        public IEnumerable<TestStudent> GetTestStudent();

        public void InsertTestResult(TestStudent testStudent);

        public void SaveTestResultsToFile(string fileName);

        public void LoadTestResultsFromFile(string fileName);

        public void SelectResultsByTestName(string testName,
                                            out IEnumerable<TestStudent> selectedTest,
                                            int maxRows = int.MaxValue,
                                            Sorting sortingForSurname = Sorting.no,
                                            int minResult = 0);

        public double GetAvverageResultsForTestName(string testName);

        public void SelectResultsBySurname(string surname,
                                           out IEnumerable<TestStudent> selectedTest,
                                           int maxRows = int.MaxValue,
                                           Sorting sortingForTestName = Sorting.no,
                                           int minResult = 0);

        public double GetAvverageResultsForSurname(string surname);

        public void SelectResultsForDate(DateTime testDate,
                                          out IEnumerable<TestStudent> selectedTest,
                                          int maxRows = int.MaxValue,
                                          Sorting sortingForTestName = Sorting.no);
    }
}

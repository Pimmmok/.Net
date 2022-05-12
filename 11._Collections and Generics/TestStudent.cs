using System;

namespace _11._Collections_and_Generics
{
    [Serializable]
    public class TestStudent : IComparable<TestStudent>
    {
        public string Name { get; }

        public string Surname { get; set; }

        public string TestName { get; set; }

        public DateTime TestDate { get; set; }

        private int _testResult;

        public int TestResult
        {
            get => _testResult;
            set
            {
                if ((value > 10) || (value < 0))
                {
                    throw new ResultStudentTestException(value, "Test result incorrect!");
                }
                else
                {
                    _testResult = value;
                }
            }
        }

        public TestStudent(string name, string surname, string testName, DateTime testDate, int testResult)
        {
            Name = name;
            Surname = surname;
            TestName = testName;
            TestDate = testDate;
            TestResult = testResult;
        }
        public TestStudent()
        {
            Name = string.Empty;
            Surname = string.Empty;
            TestName = string.Empty;
            TestDate = default;
            TestResult = 0;
        }

        public override string ToString()
        {
            return new string("Test result:"
                              + TestResult
                              + " , test: "
                              + TestName
                              + " "
                              + TestDate.ToString("d")
                              + " , student: "
                              + Surname
                              + " "
                              + Name);
        }

        public int CompareTo(TestStudent other)
        {
            if (other == null)
            {
                throw new ArgumentException("Incorrect parameter value when comparing objects");
            }

            return TestResult == other.TestResult ? 0 : TestResult > other.TestResult ? 1 : -1;
        }
    }
}

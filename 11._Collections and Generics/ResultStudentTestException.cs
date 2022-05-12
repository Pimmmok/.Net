using System;

namespace _11._Collections_and_Generics
{
    [Serializable]
    public class ResultStudentTestException : Exception
    {
        public int IncorrectResult { get; }

        public ResultStudentTestException() { }

        public ResultStudentTestException(string message) : base(message) { }

        public ResultStudentTestException(string message, Exception inner)
            : base(message, inner) { }

        public ResultStudentTestException(int incorrectResult, string message)
            : this(message)
        {
            IncorrectResult = incorrectResult;
        }
    }
}

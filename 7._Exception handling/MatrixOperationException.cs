using System;

namespace _7._Exception_handling
{
    [Serializable]
    public class MatrixOperationException : Exception
    {
        public string OperationName { get; }

        public MatrixOperationException() { }

        public MatrixOperationException(string message) : base(message) { }

        public MatrixOperationException(string message, Exception inner)
            : base(message, inner) { }

        public MatrixOperationException(string operationName, string message)
            : this(message)
        {
            OperationName = operationName;
        }
    }
}

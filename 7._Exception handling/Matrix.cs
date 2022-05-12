using System.Text;

namespace _7._Exception_handling
{
    public class Matrix
    {
        public double[,] ArrayOfValues { get; }
        public int RowsCount { get; }
        public int ColumnsCount { get; }

        public Matrix(double[,] arrayOfValues)

        {
            ArrayOfValues = arrayOfValues;
            RowsCount = arrayOfValues.GetUpperBound(0) + 1;
            ColumnsCount = arrayOfValues.Length / RowsCount;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < RowsCount; i++)
            {
                _ = stringBuilder.Append('|');
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (j == 0)
                    {
                        _ = stringBuilder.Append(ArrayOfValues[i, j].ToString());
                    }
                    else
                    {
                        _ = stringBuilder.Append(ArrayOfValues[i, j].ToString().PadLeft(10));
                    }
                }
                _ = stringBuilder.Append("|\n");
            }
            return stringBuilder.ToString();
        }

        public static Matrix operator +(Matrix matrixOne, Matrix matrixTwo)
        {
            if (matrixOne.ColumnsCount != matrixTwo.ColumnsCount || matrixOne.RowsCount != matrixTwo.RowsCount)
            {
                throw new MatrixOperationException("Matrix addition", "For matrices with different sizes, addition is not possible!");
            }
            int rows = matrixOne.RowsCount;
            int columns = matrixTwo.ColumnsCount;
            double[,] ArrayOfResultValues = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    ArrayOfResultValues[i, j] = matrixOne.ArrayOfValues[i, j] + matrixTwo.ArrayOfValues[i, j];
                }
            }
            return new Matrix(ArrayOfResultValues);
        }
        public static Matrix operator -(Matrix matrixOne, Matrix matrixTwo)
        {
            if (matrixOne.ColumnsCount != matrixTwo.ColumnsCount || matrixOne.RowsCount != matrixTwo.RowsCount)
            {
                throw new MatrixOperationException("Matrix subtraction", "For matrices of different sizes, subtraction is impossible!");
            }
            int rows = matrixOne.RowsCount;
            int columns = matrixTwo.ColumnsCount;
            double[,] ArrayOfResultValues = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    ArrayOfResultValues[i, j] = matrixOne.ArrayOfValues[i, j] - matrixTwo.ArrayOfValues[i, j];
                }
            }
            return new Matrix(ArrayOfResultValues);
        }
        public static Matrix operator *(Matrix matrixOne, Matrix matrixTwo)
        {
            int columnsCountOfMatrixOne = matrixOne.ColumnsCount;
            if (columnsCountOfMatrixOne != matrixTwo.RowsCount)
            {
                throw new MatrixOperationException("Matrix multiplication", "The number of columns of the first matrix is​​ not equal to the number " +
                    "of rows of the second matrix Multiplication is not possible.");
            }
            int numberOfRowsInResultArray = matrixOne.RowsCount;
            int numberOfColumnsInResultArray = matrixTwo.ColumnsCount;

            double[,] ArrayOfResultValues = new double[numberOfRowsInResultArray, numberOfColumnsInResultArray];
            for (int i = 0; i < numberOfRowsInResultArray; i++)
            {
                for (int j = 0; j < numberOfColumnsInResultArray; j++)
                {
                    ArrayOfResultValues[i, j] = 0;
                    for (int k = 0; k < matrixOne.ColumnsCount; k++)
                    {
                        ArrayOfResultValues[i, j] += matrixOne.ArrayOfValues[i, k] * matrixTwo.ArrayOfValues[k, j];
                    }
                }
            }
            return new Matrix(ArrayOfResultValues);
        }
    }
}






using System;

namespace _7._Exception_handling
{
    class Program
    {
        static void EnterToData(Matrix[] matrices)
        {
            int k = 1;
            do
            {
                Console.Write("Enter rows count of matrix " + k.ToString() + " (positive integer):");
                if (!uint.TryParse(Console.ReadLine(), out uint rowsCount))
                {
                    Console.WriteLine("Invalid format, please input again!");
                    continue;
                }
                Console.Write("Enter columns count of matrix " + k.ToString() + " (positive integer):");
                if (!uint.TryParse(Console.ReadLine(), out uint columnsCount))
                {
                    Console.WriteLine("Invalid format, please input again!");
                    continue;
                }
                double[,] arrayOfValues = new double[rowsCount, columnsCount];
                int i = 0;
                while (i < rowsCount)
                {
                    int j = 0;
                    while (j < columnsCount)
                    {
                        Console.Write("Enter value [ "
                            + i.ToString()
                            + " , "
                            + j.ToString()
                            + " ] of matrix "
                            + k.ToString()
                            + " (double):");
                        if (!double.TryParse(Console.ReadLine(), out double value))
                        {
                            Console.WriteLine("Invalid format, please input again!");
                            continue;
                        }
                        arrayOfValues[i, j] = value;
                        j++;
                    }
                    i++;
                }
                matrices[k - 1] = new Matrix(arrayOfValues);
                k++;
            } while (k < 3);
            Console.WriteLine("Matrices in work:");
            foreach (Matrix matrix in matrices)
            {
                Console.WriteLine(matrix);
            }
        }

        static void Main()
        {
            Console.WriteLine("Matrix");
            Matrix[] matrices = new Matrix[2];
            EnterToData(matrices);
            while (true)
            {
                try
                {
                    Console.WriteLine("What should be done?:");
                    Console.WriteLine("1. Сalculate summa (enter <1>)");
                    Console.WriteLine("2. Calculate difference (enter <2>)");
                    Console.WriteLine("3. Calculate multiplication (enter <3>)");
                    Console.WriteLine("4. Enter new matrices (enter <5>)");
                    Console.WriteLine("Enter <Q> to exit");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':

                            Console.WriteLine(matrices[0] + " + \n" + matrices[1] + " = \n" + (matrices[0] + matrices[1]));
                            break;

                        case '2':

                            Console.WriteLine(matrices[0] + " - \n" + matrices[1] + " = \n" + (matrices[0] - matrices[1]));
                            break;

                        case '3':
                            Console.WriteLine(matrices[0] + " * \n" + matrices[1] + " = \n" + (matrices[0] * matrices[1]));
                            break;

                        case '4':
                            EnterToData(matrices);
                            break;

                        case 'q':
                            return;
                        default:
                            break;
                    }
                }
                catch (MatrixOperationException ex)
                {
                    Console.WriteLine("An matrix operation exception occurred. Operation: "
                        + ex.OperationName
                        + ". Message: "
                        + ex.Message);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("An exception occurred. Type: " + ex.GetType().FullName + " Message: " + ex.Message);
                }
            }
        }
    }
}






using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace MatrixLogic
{
    public class Class1
    {
        public static class MatrixOperations
        {
            public static double[,] MatrixMultiply(double[,] matrix1, double[,] matrix2)
            {
                int rows1 = matrix1.GetLength(0);
                int cols1 = matrix1.GetLength(1);
                int rows2 = matrix2.GetLength(0);
                int cols2 = matrix2.GetLength(1);

                if (cols1 != rows2)
                    throw new ArgumentException("Количество столбцов в первой матрице должно совпадать с количеством строк во второй.");

                // Проверка значений
                for (int i = 0; i < rows1; i++)
                    for (int j = 0; j < cols1; j++)
                        if (matrix1[i, j] <= 0)
                            throw new ArgumentException($"Matrix1 содержит недопустимое значение в ячейке[{i},{j}]");

                for (int i = 0; i < rows2; i++)
                    for (int j = 0; j < cols2; j++)
                        if (matrix2[i, j] <= 0)
                            throw new ArgumentException($"Matrix2 содержит недопустимое значение в ячейке[{i},{j}]");

                double[,] result = new double[rows1, cols2];
                for (int i = 0; i < rows1; i++)
                    for (int j = 0; j < cols2; j++)
                        for (int k = 0; k < cols1; k++)
                            result[i, j] += matrix1[i, k] * matrix2[k, j];

                return result;
            }
        }
    }
}

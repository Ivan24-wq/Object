using System;
using Xunit;
using MatrixLogic; 

namespace TestProject1
{
    public class MatrixTests
    {
        [Fact]
        public void MatrixMultiply_ValidMatrices_ReturnsCorrectResult()
        {
            
            double[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            double[,] matrix2 = { { 5, 6 }, { 7, 8 } };
            double[,] expected = { { 19, 22 }, { 43, 50 } };

           
            double[,] actual = Class1.MatrixOperations.MatrixMultiply(matrix1, matrix2);

            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MatrixMultiply_MatrixWithNegativeValue_ThrowsArgumentException()
        {
            
            double[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            double[,] matrix2 = { { 5, -6 }, { 7, 8 } };

            
            Assert.Throws<ArgumentException>(() =>
                Class1.MatrixOperations.MatrixMultiply(matrix1, matrix2));
        }

        [Fact]
        public void MatrixMultiply_IncompatibleMatrices_ThrowsArgumentException()
        {
            
            double[,] matrix1 = { { 1, 2, 3 }, { 4, 5, 6 } };
            double[,] matrix2 = { { 1, 2 }, { 3, 4 } };

            
            Assert.Throws<ArgumentException>(() =>
                Class1.MatrixOperations.MatrixMultiply(matrix1, matrix2));
        }
    }
}

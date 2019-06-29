using System;
using System.Linq;

namespace Square_With_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int row = rowsAndCols[0];
            int col = rowsAndCols[1];

            int[,] matrix = new int[row, col];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = currentRow[cols];
                }
            }

            int maxSum = 0;
            int sum = 0;
            int rowIndex = 0;
            int colIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    sum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows + 1, cols] + matrix[rows + 1, cols + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex+1]}");
            Console.WriteLine($"{matrix[rowIndex+1, colIndex]} {matrix[rowIndex+1, colIndex+1]}");
            Console.WriteLine(maxSum);
        }
    }
}

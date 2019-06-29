using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int coloumns = input[1];
            int[,] matrix = new int[rows, coloumns];
            int sum = 0;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < coloumns; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int tempSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine(matrix[rowIndex, colIndex] + " " + matrix[rowIndex, colIndex + 1]);
            Console.WriteLine(matrix[rowIndex + 1, colIndex] + " " + matrix[rowIndex + 1, colIndex + 1]);
            Console.WriteLine(sum);
        }
    }
}

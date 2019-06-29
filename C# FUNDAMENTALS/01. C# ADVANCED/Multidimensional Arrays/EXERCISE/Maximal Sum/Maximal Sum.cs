using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int rowIndex = 0;
            int colIndex = 0;
            int maxSum = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int tempSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                                + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                                + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[rowIndex][colIndex]} {matrix[rowIndex][colIndex + 1]} {matrix[rowIndex][colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 1][colIndex]} {matrix[rowIndex + 1][colIndex + 1]} {matrix[rowIndex + 1][colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 2][colIndex]} {matrix[rowIndex + 2][colIndex + 1]} {matrix[rowIndex + 2][colIndex + 2]}");

        }
    }
}

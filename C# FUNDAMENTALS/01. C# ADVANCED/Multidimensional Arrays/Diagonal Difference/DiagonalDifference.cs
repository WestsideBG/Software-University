using System;
using System.Linq;

namespace Diagonal_Difference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;
            for (int i = 0; i < n; i++)
            {
                primarySum += matrix[i, i];
            }

            int col = n - 1;
            for (int i = 0; i < n; i++)
            {
                secondarySum += matrix[i, col];
                col--;
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));


        }
    }
}

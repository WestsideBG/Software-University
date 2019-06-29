using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int primarySum = 0;
            int secondarySum = 0;
            for (int row = 0; row < n; row++)
            {
                primarySum += matrix[row][row];

            }
            int col = n - 1;
            for (int row = 0; row < n; row++)
            {
                secondarySum += matrix[row][col];
                col--;
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}

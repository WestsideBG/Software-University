using System;
using System.Linq;

namespace Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int coloumns = input[1];
            int[,] matrix = new int[rows, coloumns];

            for (int row = 0; row < rows; row++)
            {
            int[] values = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < coloumns; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(rows);
            Console.WriteLine(coloumns);
            Console.WriteLine(sum);
        }
    }
}
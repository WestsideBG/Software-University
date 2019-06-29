using System;
using System.Linq;

namespace _2x2_Square_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int row = rowsAndCols[0];
            int col = rowsAndCols[1];
            string[][] matrix = new string[row][];


            for (int i = 0; i < row; i++)
            {
                matrix[i] = Console.ReadLine().Split().ToArray();
            }

            int counter = 0;

            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < col - 1; j++)
                {
                    if (matrix[i][j] == matrix[i][j + 1] && matrix[i][j] == matrix[i + 1][j] && matrix[i][j] == matrix[i + 1][j+1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}

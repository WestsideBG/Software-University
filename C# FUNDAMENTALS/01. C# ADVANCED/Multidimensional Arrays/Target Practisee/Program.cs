using System;
using System.Linq;

namespace Target_Practisee
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string snake = Console.ReadLine();

            int rows = dimension[0];
            int cols = dimension[1];

            char[][] matrix = new char[rows][];

            FillMatrix(matrix, rows, cols, snake);
            PrintMatrix(matrix);

        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void FillMatrix(char[][] matrix, int rows, int cols, string snake)
        {
            int counter = 0;

            bool isLeft = true;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (counter > snake.Length - 1)
                            counter = 0;
                        matrix[row][col] = snake[counter++];
                        isLeft = false;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (counter > snake.Length - 1)
                            counter = 0;
                        matrix[row][col] = snake[counter++];
                        isLeft = true;
                    }
                }

            }
        }
    }
}

using System;
using System.Linq;

namespace Symbol_in_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int rows = 0; rows < n; rows++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = currentRow[cols];
                }
            }

            string symbol = Console.ReadLine();
            int rowIndex = 0;
            int colIndex = 0;
            bool isExist = false;

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    if (matrix[rows, cols].ToString() == symbol)
                    {
                        rowIndex = rows;
                        colIndex = cols;
                        isExist = true;
                        break;
                    }
                }

                if (isExist)
                {
                    break;
                }
            }

            if (isExist)
            {
                Console.WriteLine($"({rowIndex}, {colIndex})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }

        }
    }
}

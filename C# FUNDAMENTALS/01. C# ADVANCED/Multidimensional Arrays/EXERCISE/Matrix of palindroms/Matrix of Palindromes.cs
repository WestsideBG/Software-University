using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows,cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    char letter = (char)alphabet[i];
                    char midLetter = (char)alphabet[i + j];
                    matrix[i, j] = letter.ToString() + midLetter.ToString() + letter.ToString();
                }
            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
            
        }
    }
}

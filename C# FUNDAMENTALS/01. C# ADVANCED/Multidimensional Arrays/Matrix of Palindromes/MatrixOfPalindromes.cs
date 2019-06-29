using System;
using System.Linq;

namespace Matrix_of_Palindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string[,] matrixOfPalindromes = new string[rows, cols];

            for (int i = 0; i < matrixOfPalindromes.GetLength(0); i++)
            {
                char firstAndLastLetter = (char)alphabet[i];

                for (int j = 0; j < matrixOfPalindromes.GetLength(1); j++)
                {
                    char middleLetter = (char)alphabet[i + j];
                    matrixOfPalindromes[i, j] = firstAndLastLetter.ToString() + middleLetter.ToString() + firstAndLastLetter.ToString();
                    Console.Write(matrixOfPalindromes[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

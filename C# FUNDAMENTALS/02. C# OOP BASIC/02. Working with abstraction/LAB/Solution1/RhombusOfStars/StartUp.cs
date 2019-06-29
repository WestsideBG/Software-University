using System;

namespace RhombusOfStars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintRow(n, i);
            }

            for (int i = n - 1; i >= 1; i--)
            {
                PrintRow(n, i);
            }
        }

        private static void PrintRow(int size, int starCounter)
        {
            for (int i = 0; i < size - starCounter; i++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j < starCounter; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}

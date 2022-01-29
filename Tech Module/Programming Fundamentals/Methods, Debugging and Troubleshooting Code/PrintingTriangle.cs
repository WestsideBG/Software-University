using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class PrintingTriangle
    {
        public PrintingTriangle()
        {
        }

        internal void Run()
        {
            int num = GetNumber();
            PrintTriangle(num);
        }

        private void PrintTriangle(int n)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i <= n; i++)
            {
                PrintLine(1, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                PrintLine(1, i);
            }
            Console.ResetColor();
        }

        private void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        private int GetNumber()
        {
            Console.WriteLine("Please, provide a number:");
            int n = int.Parse(Console.ReadLine());
            return n;
        }
    }
}
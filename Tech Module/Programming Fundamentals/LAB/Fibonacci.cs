using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class Fibonacci
    {
        internal void Run()
        {
            int n = GetInputNumber();
            int fibonacci = GetFibonacci(n);
            PrintOutput(fibonacci);
        }

        private void PrintOutput(int fibonacci)
        {
            Console.WriteLine($"The fibonacci number is {fibonacci}");
        }

        private int GetFibonacci(int n)
        {
            int a = 0;
            int b = 1;
            // In N steps, compute Fibonacci sequence iteratively.
            for (int i = 0; i <= n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        private int GetInputNumber()
        {
            Console.WriteLine("This method returns the given number's fibonacci number.");
            Console.WriteLine("Please, provide a number.");
            int n = int.Parse(Console.ReadLine());
            return n;
        }
    }
}
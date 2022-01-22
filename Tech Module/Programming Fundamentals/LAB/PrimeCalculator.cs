using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class PrimeCalculator
    {
        internal void Run()
        {
            decimal n = GetInputNumber();
            PrintOutput(n,IsPrime(n));
        }

        private void PrintOutput(decimal n,bool v)
        {
            if (v)
            {
                Console.WriteLine($"The number {n} is a prime number!");
            }
            else
                Console.WriteLine($"The number {n} is not a prime number!");
        }

        private bool IsPrime(decimal n)
        {
            int primeCounter = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    primeCounter++;
            }

            if (primeCounter == 2)
                return true;
            else
                return false;
        }

        private decimal GetInputNumber()
        {
            Console.WriteLine("This method cheks whether a given integer number n is prime.");
            Console.WriteLine("Please, provide a number:");
            decimal n = decimal.Parse(Console.ReadLine());
            return n;
        }
    }
}
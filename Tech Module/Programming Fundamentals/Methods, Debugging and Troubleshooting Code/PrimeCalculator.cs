namespace Methods__Debugging_and_Troubleshooting_Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PrimeCalculator
    {
        internal void Run(string name, bool isRange)
        {
            if (!isRange)
            {
                decimal n = GetInputNumber();
                PrintOutput(n, IsPrime(n));
            }
            else
            {
                decimal[] range = GetRangeNumbers();
                List<decimal> primeNumbers = GePrimeNumbers(range);
                PrintRangeOutput(name,primeNumbers);
            }
        }

        private void PrintRangeOutput(string name,List<decimal> primeNumbers)
        {
            if (!primeNumbers.Any())
            {
                Console.WriteLine("There is no prime numbers in this range!");
                Console.WriteLine("Do you want to try again? [Y/N]");
                string yesorno = Console.ReadLine();
                if (yesorno == "Y" || yesorno == "y")
                    Run(name,true);
                else
                    StartUp.SayGoodBye(name);
            }
            else
            {
                Console.WriteLine("The prime numbers in this range are:");
                Console.WriteLine(String.Join(" ,", primeNumbers));
            }
        }

        private List<decimal> GePrimeNumbers(decimal[] range)
        {
            List<decimal> primeNumbers = new List<decimal>();
            decimal startingNumber = range[0];
            decimal endingNumber = range[1];
            for (decimal i = startingNumber; i <= endingNumber; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }
            return primeNumbers;
        }

        private decimal[] GetRangeNumbers()
        {
            Console.WriteLine("This method will return all prime numbers in range");
            Console.WriteLine("Please, provide a starting number");
            decimal startingNumber = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please, provide a ending number");
            decimal endingNumber = decimal.Parse(Console.ReadLine());

            return new decimal[] { startingNumber, endingNumber };
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            Func<int,int> add = n => n + 1;
            Func<int,int> multiply = n => n * 2;
            Func<int,int> subtract = n => n - 1;
            Action<List<int>> print = a => Console.WriteLine(string.Join(" ",a));

            while (command != "end")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (command == "add")
                    {
                        numbers[i] = add(numbers[i]);
                    }
                    else if (command == "multiply")
                    {
                        numbers[i] = multiply(numbers[i]);
                    }
                    else if (command == "subtract")
                    {
                        numbers[i] = subtract(numbers[i]);
                    }
                }
                if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}

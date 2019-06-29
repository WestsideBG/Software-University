using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(' ');
                int command = int.Parse(elements[0]);
                if (command == 1)
                {
                    int number = int.Parse(elements[1]);
                    numbers.Push(number);
                }
                else if (command == 2)
                {
                    numbers.Pop();

                }
                else if (command == 3)
                {
                    Console.WriteLine(numbers.Max());
                }
            }

        }
    }
}

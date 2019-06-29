using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_Or_Odd
{
    class FindEvensOrOdd
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            Func<int, bool> isEven = n => n % 2 == 0;
            Func<int, bool> isOdd = n => n % 2 != 0;
            List<int> result = new List<int>();

            for (int i = input[0]; i <= input[1]; i++)
            {
                if (command == "even" && isEven(i))
                {
                    result.Add(i);
                }
                else if (command == "odd" && isOdd(i))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

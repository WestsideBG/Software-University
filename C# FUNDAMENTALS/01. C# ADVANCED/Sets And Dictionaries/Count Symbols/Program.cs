using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Dictionary<char, int> counter = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!counter.ContainsKey(input[i]))
                {
                    counter.Add(input[i], 0);
                }

                counter[input[i]]++;
            }

            foreach (var symbol in counter.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }

        }
    }
}

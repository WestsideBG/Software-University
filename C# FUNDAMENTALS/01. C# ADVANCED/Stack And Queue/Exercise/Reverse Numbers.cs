using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            Stack<string> reverse = new Stack<string>(input);

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(reverse.Pop() + " ");
            }
            Console.WriteLine();

        }
    }
}

using System;
using System.Collections.Generic;

namespace Stack_and_Queues_LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> reverse = new Stack<char>();


            for (int i = 0; i < input.Length; i++)
            {
                reverse.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(reverse.Pop());
            }

        }
    }
}

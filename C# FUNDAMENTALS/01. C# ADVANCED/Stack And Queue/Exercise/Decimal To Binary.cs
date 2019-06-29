using System;
using System.Collections.Generic;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> binary = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(input);
            }
            else
            {
                while (input != 0)
                {
                    binary.Push(input % 2);
                    input /= 2;
                }
            }

            while (binary.Count > 0)
            {
                Console.Write(binary.Pop());
            }
        }
    }
}

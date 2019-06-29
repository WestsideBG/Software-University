using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var tokens = input.Split(' ').ToArray();
            Stack<string> sum = new Stack<string>(tokens.Reverse());

            while (sum.Count > 1)
            {
                int first = int.Parse(sum.Pop());
                string sign = sum.Pop();
                int second = int.Parse(sum.Pop());

                if (sign == "+")
                {
                    sum.Push((first + second).ToString());
                }
                else
                {
                    sum.Push((first - second).ToString());
                }
            }

            Console.WriteLine(sum.Pop());
        }
    }
}

using System;
using System.Collections.Generic;

namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fibNumber = new Stack<long>();

            fibNumber.Push(0);
            fibNumber.Push(1);

            for (int i = 0; i < n; i++)
            {
                long first = fibNumber.Pop();
                long second = fibNumber.Pop();
                fibNumber.Push(first);
                fibNumber.Push(first + second);
            }

            fibNumber.Pop();
            Console.WriteLine(fibNumber.Peek());
        }
    }
}
using System;
using System.Collections.Generic;

namespace Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> numbers = new Queue<long>();
            List<long> result = new List<long>();
            numbers.Enqueue(n);
            result.Add(n);

            while (result.Count < 50)
            {
                long currElement = numbers.Dequeue();
                long firstNumber = currElement + 1;
                long secondNumber = (currElement * 2) + 1;
                long thirdNumber = currElement + 2;

                numbers.Enqueue(firstNumber);
                numbers.Enqueue(secondNumber);
                numbers.Enqueue(thirdNumber);

                result.Add(firstNumber);
                result.Add(secondNumber);
                result.Add(thirdNumber);
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(result[i] + " ");
            }

        }
    }
}

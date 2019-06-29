using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> nums = new Queue<int>(numbers);
            int index = 0;

            int pop = commands[1];
            int magicNumber = commands[2];
            int smallestNumber = 0;

            for (int i = 0; i < pop; i++)
            {
                nums.Dequeue();
            }

            if (nums.Contains(magicNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                while (nums.Count != 0)
                {
                    int currNumber = nums.Dequeue();
                    

                    if (index == 0)
                        smallestNumber = currNumber;
                    if (smallestNumber > currNumber)
                    {
                        smallestNumber = currNumber;
                    }
                    index++;
                }
                Console.WriteLine(smallestNumber);
            }






        }
    }
}

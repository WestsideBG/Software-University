using System;
using System.Collections.Generic;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split(' ');

            int pop = int.Parse(commands[1]);
            int number = int.Parse(commands[2]);

            var elements = Console.ReadLine().Split(' ');
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < elements.Length; i++)
            {

                numbers.Push(int.Parse(elements[i]));

            }
            int smallest = 0;
            int index = 0;

            for (int i = 0; i < pop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(number))
            {
                Console.WriteLine("true");
            }
            else
            {
                while (numbers.Count != 0)
                { 
                    int currNumber = numbers.Pop();
                    if (index == 0)
                    {
                        smallest = currNumber;
                        
                    }
                 
                    if (smallest > currNumber)
                    {
                        smallest = currNumber;
                    }

                    index++;
                }
                Console.WriteLine(smallest);
            }

            

        }
    }
}

using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class ReverseArray
    {
        public ReverseArray()
        {
        }

        internal void Run()
        {
            int[] input = GetInput();
            
            Array.Reverse(input);
            PrintInput(input);
        }

        private void PrintInput(int[] input)
        {
            Console.WriteLine("RESULT:");
            Console.WriteLine(String.Join(" ",input));
        }

        private int[] GetInput()
        {
            Console.WriteLine("This exercise program reads an array of integers, reverse it and prints its elements.");
            Console.WriteLine("Please, provide a number which will be array's count");
            int count = Convert.ToInt32(Console.ReadLine());
            int[] input = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Please, provide a number:");
                input[i] = Convert.ToInt32(Console.ReadLine());
            }

            return input;
        }
    }
}
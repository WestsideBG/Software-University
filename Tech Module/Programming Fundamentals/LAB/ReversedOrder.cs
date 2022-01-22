
namespace Methods__Debugging_and_Troubleshooting_Code
{
    using System;
    using System.Linq;
    internal class ReversedOrder
    {
        internal void Run()
        {
            char[] input = ReadInput();
            char[] reversedInput = ReverseInput(input);
            PrintReversedInput(reversedInput);
        }

        private static void PrintReversedInput(char[] reversedInput)
        {
            Console.Write("The reversed number is: ");
            Console.Write(string.Join("",reversedInput));
            Console.WriteLine();
        }

        private static char[] ReverseInput(char[] input)
        {
            char[] reversedInput = input.Reverse().ToArray();
            return reversedInput;
        }

        private static char[] ReadInput()
        {
            Console.WriteLine("This method prints the digits of a given decimal number in a reversed order.");
            Console.WriteLine("Please, provide a number:");
            char[] input = Console.ReadLine().ToCharArray();
            return input;
        }
    }
}

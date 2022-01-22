using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class MaxMethod
    {
        private int GetMaxNumber(int firstNumber, int secondNumber)
        {
            return Math.Max(firstNumber,secondNumber);
        }
        
        private int[] GetNumbers()
        {
            System.Console.WriteLine("This Method have two integer parameters, and returns the bigger one.");
            System.Console.WriteLine("Please, provide a integer one:");
            int firstNumber = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Please, provide a integer two:");
            int secondNumber = int.Parse(Console.ReadLine());

            return new int[] { firstNumber,secondNumber};
        }

        internal void Run()
        {
            int[] numbers = GetNumbers();
            int number = GetMaxNumber(numbers[0], numbers[1]);
            Console.WriteLine($"The biggest number is: {number}");
        }
    }
}
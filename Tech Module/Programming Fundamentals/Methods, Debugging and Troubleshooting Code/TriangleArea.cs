using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class TriangleArea
    {
        internal void Run()
        {
            Console.WriteLine("This method calculates triangle's area.");
            Console.WriteLine("Please, provide a width:");
            double[] input = GetInput();
            double area = CalculateArea(input);
            PrintArea(area);
        }

        private void PrintArea(double area)
        {
            Console.WriteLine($"The area is: {area}");
        }

        private double CalculateArea(double[] input)
        {
            return input[0] * input[1] / 2;
        }

        private double[] GetInput()
        {
            double width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please,provide a height:");
            double height = Convert.ToDouble(Console.ReadLine());

            return new double[] { width, height };
        }
    }
}
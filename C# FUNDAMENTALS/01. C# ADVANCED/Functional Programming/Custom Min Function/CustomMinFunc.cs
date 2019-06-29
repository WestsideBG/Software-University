using System;
using System.Linq;

namespace Custom_Min_Function
{
    class CustomMinFunc
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> func = ReturnMinValue;

            Console.WriteLine(func(input));
        }

        public static int ReturnMinValue (int[] array)
        {
            int minValue = array.Min();

            return minValue;
        }
    }
}

using System;
using System.Linq;

namespace Reverse_And_Exclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());
            Func<int, bool> isDivisible = n => n % num != 0;
            int[] reversed = numbers.Reverse().Where(isDivisible).ToArray();
            Action<int[]> print = a => Console.WriteLine(String.Join(" ", a));
            print(reversed);
        }
    }
}

using System;

namespace Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            long p = long.Parse(Console.ReadLine());

            double distance = (n / 1000) * m;
            double time = (n / 100) + (n / p) * 5;

            Console.WriteLine($"{distance:F2} m.");
            Console.WriteLine($"{time} s.");


        }
    }
}

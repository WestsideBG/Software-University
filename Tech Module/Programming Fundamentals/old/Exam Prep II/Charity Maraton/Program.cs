using System;

namespace Charity_Maraton
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthDays = int.Parse(Console.ReadLine());
            long runners = int.Parse(Console.ReadLine());
            int avg = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            long maxCapacity = lengthDays * trackCapacity;

            if (runners > maxCapacity)
            {
                runners = maxCapacity;
            }

            long totalMeters = runners * avg * trackLength;

            long totalKm = totalMeters / 1000;

            double money = totalKm * moneyPerKm;

            Console.WriteLine($"Money raised: {money:F2}");





        }
    }
}

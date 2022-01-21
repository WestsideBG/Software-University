using System;
using System.Globalization;

namespace Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            int num = int.Parse(Console.ReadLine()) % 86400;

            int sec = int.Parse(Console.ReadLine()) % 86400;

            int allSec = num * sec;

            time = time.AddSeconds(allSec);

           string output =  time.ToString("HH:mm:ss");

            Console.WriteLine($"Time Arrival: {output}");

           




        }
    }
}

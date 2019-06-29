using System;
using System.Linq;

namespace _06.TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            var trafficLights = Console.ReadLine().Trim().Split()
                .Select(x => new TrafficLight(x))
                .ToList();

            var n = int.Parse(Console.ReadLine().Trim());

            for (int i = 0; i < n; i++)
            {
                trafficLights.ForEach(t => t.ToggleSignal());
                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}

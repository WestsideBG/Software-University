using System;
using System.Linq;

namespace Rally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] drivers = Console.ReadLine().Split();

            double[] zones = Console.ReadLine().Split().Select(double.Parse).ToArray();

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            double[] fuel = new double[drivers.Length];

            for (int i = 0; i < drivers.Length; i++)
            {
                fuel[i] = (double)drivers[i][0];
            }

            for (int i = 0; i < zones.Length; i++)
            {
                if (indexes.Contains(i))
                {
                    for (int j = 0; j < drivers.Length; j++)
                    {
                        if (fuel[j] > 0)
                        {
                            fuel[j] += zones[i];
                        }
                    }                     
                }
                else
                {

                    for (int j = 0; j < drivers.Length; j++)
                    {
                        if (fuel[j] > 0)
                        {
                            fuel[j] -= zones[i];

                            if (fuel[j] <= 0)
                            {
                                fuel[j] = i * -1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < drivers.Length; i++)
            {
                if (fuel[i] > 0)
                {
                    Console.WriteLine($"{drivers[i]} - fuel left {fuel[i]:F2}");
                }
                else
                {
                    Console.WriteLine($"{drivers[i]} - reached {fuel[i] * -1} ");
                }
            }

            
        }
    }
}

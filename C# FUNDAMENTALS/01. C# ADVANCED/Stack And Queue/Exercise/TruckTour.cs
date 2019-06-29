using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> petrolPumps = new Queue<int[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                petrolPumps.Enqueue(input);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var pump in petrolPumps)
                {
                    int fuel = pump[0];
                    int distance = pump[1];

                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        index++;

                        int[] pumpForRemove = petrolPumps.Dequeue();
                        petrolPumps.Enqueue(pumpForRemove);
                        break;
                    }

                }

                if (totalFuel >= 0)
                {
                    break;
                }

            }
            Console.WriteLine(index);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace HonetAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] beehieves = Console.ReadLine().Split().Select(long.Parse).ToArray();
            List<long> hornets = Console.ReadLine().Split().Select(long.Parse).ToList();

            for (int i = 0; i < beehieves.Length; i++)
            {
                if (hornets.Count == 0)
                {
                    break;
                }

                long behavieCount = beehieves[i];
                long sum = hornets.Sum();

                beehieves[i] -= sum;

                if (behavieCount >= sum)
                {
                    hornets.RemoveAt(0);
                }

               
            }
            if (beehieves.Any(x => x > 0))
            {
                Console.WriteLine(string.Join(" ", beehieves.Where(x => x > 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}

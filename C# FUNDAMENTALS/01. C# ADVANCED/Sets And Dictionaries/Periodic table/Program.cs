using System;
using System.Collections.Generic;

namespace Periodic_table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> table = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicals = Console.ReadLine().Split();

                for (int j = 0; j < chemicals.Length; j++)
                {

                    table.Add(chemicals[j]);
                }

            }

            Console.WriteLine(string.Join(" ", table));
        }
    }
}

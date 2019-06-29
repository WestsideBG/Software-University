using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int nSetLenght = input[0];
            int mSetLenght = input[1];

            HashSet<int> n = new HashSet<int>(nSetLenght);
            HashSet<int> m = new HashSet<int>(mSetLenght);

            bool isBigest = nSetLenght >= mSetLenght;

            for (int i = 1; i <= nSetLenght + mSetLenght; i++)
            {
                int currentElement = int.Parse(Console.ReadLine());

                if (i <= nSetLenght)
                {
                    n.Add(currentElement);
                }
                else
                {
                    m.Add(currentElement);
                }
            }

            var result = n.Intersect(m);
            

            Console.WriteLine(string.Join(" ",result));
            
        }
    }
}

using System;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            decimal half = n * 0.5m;

            int count = 0;
            while (n > m)
            {
                n -= m;
                count++;
                if (n == half && y > 0)
                {
                    n /= y;
                }


            }
            Console.WriteLine(n);
            Console.WriteLine(count);

        }
    }
}

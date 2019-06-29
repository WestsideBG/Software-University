using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal snowballsCount = int.Parse(Console.ReadLine());

            BigInteger maxValue = 0;
            decimal maxSnow = 0;
            decimal maxTime = 0;
            decimal maxQuality = 0;

            for (int i = 0; i < snowballsCount; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime  = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowBallValue = BigInteger.Pow(snowballSnow / snowballTime,snowballQuality) ;

                if (snowBallValue > maxValue)
                {
                    maxValue = snowBallValue;
                    maxSnow = snowballSnow;
                    maxTime = snowballTime;
                    maxQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{maxSnow} : {maxTime} = {maxValue} ({maxQuality})");

        }
    }
}

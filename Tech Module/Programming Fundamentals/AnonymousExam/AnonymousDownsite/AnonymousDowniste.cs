using System;
using System.Numerics;

namespace AnonymousDownsite
{
    class AnonymousDowniste
    {
        static void Main(string[] args)
        {
            int siteCount = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            decimal totalLoss = 0.0m;
            BigInteger securityToken = BigInteger.Pow(securityKey, siteCount);

            for (int i = 0; i < siteCount; i++)
            {
                string[] currentSite = Console.ReadLine().Split();

                string siteName = currentSite[0];
                decimal siteVisits = decimal.Parse(currentSite[1]);
                decimal siteCommercialPricePerVisit = decimal.Parse(currentSite[2]);

                totalLoss += siteVisits * siteCommercialPricePerVisit;
                Console.WriteLine(siteName);

            }

            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            Console.WriteLine($"Security Token: {securityToken}");

        }
    }
}

using System;
using System.Globalization;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal price = 0;
            decimal totalPrice = 0;
            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime inputtedDate = DateTime.ParseExact(Console.ReadLine(),"d/M/yyyy", CultureInfo.InvariantCulture);
                decimal capsuleCount = int.Parse(Console.ReadLine());
                decimal days = DateTime.DaysInMonth(inputtedDate.Year,inputtedDate.Month);
                price = (days * capsuleCount) * pricePerCapsule;
                totalPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}

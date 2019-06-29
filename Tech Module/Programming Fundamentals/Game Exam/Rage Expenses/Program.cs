using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ListExer
{
    class Program
    {

        static void Main(string[] args)
        {

            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int headsetCount = lostGamesCount / 2;
            int mouseCount = lostGamesCount / 3;
            int keyboardCount = lostGamesCount / 6;
            int displauCount = keyboardCount / 2;

            double headsetSum = headsetCount * headsetPrice;
            double mouseSum = mouseCount * mousePrice;
            double keyboardSum = keyboardCount * keyboardPrice;
            double displaySum = displauCount * displayPrice;


            double sum = headsetSum + mouseSum + keyboardSum + displaySum;




            Console.WriteLine($"Rage expenses: {sum:F2} lv.");


        }
    }
}
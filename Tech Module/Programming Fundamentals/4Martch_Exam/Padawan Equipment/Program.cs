using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());
            int beltsCount = 0;
            int robesCount = students;
            int lightsabresCount = (int)Math.Ceiling(students * 1.10);

            if (students == 0)
            {
                beltsCount = 0;
            }
            else
            {
                beltsCount = students - (students / 6);
            }

            double sum = (lightsabersPrice * lightsabresCount) + (beltsCount * beltsPrice) + (robesPrice * robesCount);

            if (sum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {sum-money:F2}lv. more.");
            }
        }
    }
}

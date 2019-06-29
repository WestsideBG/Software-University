using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier difference = new DateModifier();

            double days = difference.GetDifference(firstDate, secondDate);

            Console.WriteLine(Math.Abs(days));

        }
    }
}

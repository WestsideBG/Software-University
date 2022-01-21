using System;
using System.Text.RegularExpressions;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Judge - 90/100. Needs 5 or more conditionals for 10 points....

            string surface = Console.ReadLine();
            string mantle = Console.ReadLine();
            string middle = Console.ReadLine();
            string secondMantle = Console.ReadLine();
            string secondSurface = Console.ReadLine();

            string surfacePattern = @"[^A-Za-z0-9]+";
            string mantlePattern = @"[\d_]+";
            string middlePattern = @"([^A-Za-z0-9]+)([\d_]+)([A-Za-z]+)([\d_]+)([^A-Za-z0-9]+)";



            Match findCore = Regex.Match(middle, @"([^A-Za-z0-9]+)([\d_]+)([A-Za-z]+)([\d_]+)([^A-Za-z0-9]+)");

            if (!Regex.IsMatch(surface, surfacePattern)
                || !Regex.IsMatch(mantle, mantlePattern)
                || !Regex.IsMatch(middle, middlePattern)
                || !Regex.IsMatch(secondMantle, mantlePattern)
                || !Regex.IsMatch(secondSurface, surfacePattern))
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                Console.WriteLine("Valid");
                var core = findCore.Groups[3];
                Console.WriteLine(core.Length);
            }

        }
    }
}

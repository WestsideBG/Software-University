using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Star_Enigma
{
    class Program
    {

        static void Main(string[] args)
        {
            string starPattern = @"[SsTtAaRr]";
            string decMessagePattern = @"[^@\-!>]*@([A-Za-z]+)[^@\-!>]*:(\d+)[^@\-!>]*!(A|D)![^@\-!>]*->(\d+)[^@\-!>]*";

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            StringBuilder sb = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                MatchCollection star = Regex.Matches(message, starPattern);

                int step = star.Count;

                char[] arr = message.ToCharArray();

                foreach (var symbol in arr)
                {
                    sb.Append(Convert.ToChar(symbol - step));
                }

                string newMess = sb.ToString();

                Match currMess = Regex.Match(newMess,decMessagePattern);

                if (currMess.Success)
                {
                    string planetName = currMess.Groups[1].ToString();
                    int population = int.Parse(currMess.Groups[2].ToString());
                    string attackType = currMess.Groups[3].ToString();
                    int soliderCount = int.Parse(currMess.Groups[4].ToString());

                    if (attackType == "A")
                    {
                        attacked.Add(planetName);
                    }
                    else if (attackType == "D")
                    {
                        destroyed.Add(planetName);
                    }

                    sb.Clear();

                }

            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var planet in attacked.OrderBy(x => x))
            {

                Console.WriteLine($"-> {planet}");

            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var planet in destroyed.OrderBy(x => x))
            {

                Console.WriteLine($"-> {planet}");

            }

        }
    }
}

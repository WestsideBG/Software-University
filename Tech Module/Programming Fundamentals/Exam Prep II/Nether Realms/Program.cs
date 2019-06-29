using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string healthPattern = @"[A-Za-z]+";
            string damagePattern = @"([+-]*[\d]+[.]*[\d]*)";
            string multiplyOrDividePattern = @"[\/|*]";





            foreach (var names in input.OrderBy(x => x))
            {
                int health = 0;
                double damage = 0.0;
                MatchCollection healthMatch = Regex.Matches(names, healthPattern);
                MatchCollection damageMatch = Regex.Matches(names, damagePattern);
                MatchCollection multiplyOrDivideMatch = Regex.Matches(names, multiplyOrDividePattern);

                for (int i = 0; i < healthMatch.Count; i++)
                {
                    string healthStr = healthMatch[i].Value;
                    char[] arr = healthStr.ToCharArray();
                    for (int j = 0; j < arr.Length; j++)
                    {
                        health += arr[j];
                    }
                }

                foreach (Match match in damageMatch)
                {
                    damage += double.Parse(match.Value);
                }



                if (multiplyOrDivideMatch.Count > 0)
                {
                    int starIndex = names.IndexOf("*");
                    int divideIndex = names.IndexOf("/");

                    for (int i = 0; i < multiplyOrDivideMatch.Count; i++)
                    {

                        if (starIndex > divideIndex)
                        {

                            if (multiplyOrDivideMatch[i].Value.Contains("/"))
                            {
                                damage /= 2;
                            }
                            else
                            {

                                if (multiplyOrDivideMatch[i].Value.Contains("*"))
                                {
                                    damage *= 2;
                                }
                            }
                        }
                    }

                }
                Console.WriteLine($"{names} - {health} health, {damage:F2} damage");
            }
        }
    }
}

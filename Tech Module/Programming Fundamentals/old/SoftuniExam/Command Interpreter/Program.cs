using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToUpper();

            string pattern = @"([\D]+)([\d]+)";

            MatchCollection matches = Regex.Matches(input, pattern);

            List<char> cur = new List<char>();

            int count = 0;

            foreach (Match match in matches)
            {

                cur = match.Groups[1].ToString().ToCharArray().ToList();

                for (int i = 0; i < cur.Count; i++)
                {
                    for (int j = 1 ; j < cur.Count -1; j++)
                    {
                        if (cur[i] == cur[j])
                        {
                            cur.RemoveAt(i);
                        }
                    }
                }
                count += cur.Count();
            }

            Console.WriteLine($"Unique symbols used: {count}");

            foreach (Match match in matches)
            {
                int digit = int.Parse(match.Groups[2].ToString());
                string symbols = match.Groups[1].ToString();

                for (int i = 0; i < digit; i++)
                {
                    Console.Write(symbols);
                }
            }
            Console.WriteLine();




        }
    }
}

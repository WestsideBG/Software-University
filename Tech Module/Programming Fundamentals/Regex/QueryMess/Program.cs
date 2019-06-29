using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QuueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string spacePattern = @"(\+|%20)+";

            Regex pattern = new Regex(@"([^=&?\n]+)=([^=&?\n]+)");

            while (input != "END")
            {
                var matches = pattern.Matches(input);

                Dictionary<string, List<string>> queries = new Dictionary<string, List<string>>();

                foreach (Match match in matches)
                {
                    string key = match.Groups[1].ToString();
                    key = Regex.Replace(key, spacePattern, " ").Trim();

                    string value = match.Groups[2].ToString();
                    value = Regex.Replace(value, spacePattern, " ").Trim();

                    if (!queries.ContainsKey(key))
                    {
                        queries.Add(key, new List<string>());
                    }

                    queries[key].Add(value);
                }

                foreach (var query in queries)
                {
                    Console.Write($"{query.Key}=[{string.Join(", ",query.Value)}]");
                }
                Console.WriteLine();

                input = Console.ReadLine();

            }

        }
    }
}

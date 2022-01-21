using System;
using System.Collections.Generic;
using System.Linq;

namespace Force_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

            while (input != "Lumpawaroo")
            {

                if (input.Contains("|"))
                {
                    string[] tokens = input.Split(" | ");
                    string side = tokens[0];
                    string user = tokens[1];

                    if (!data.ContainsKey(side))
                    {
                        data.Add(side, new List<string>());
                    }

                    if (!data[side].Contains(user))
                    {
                        data[side].Add(user);
                    }

                }
                else
                {

                    string[] tokens = input.Split(" -> ");
                    string side = tokens[1];
                    string user = tokens[0];


                    foreach (var removed in data)
                    {
                        if (removed.Value.Contains(user))
                        {
                            removed.Value.Remove(user);
                        }

                    }

                    if (!data.ContainsKey(side))
                    {
                        data.Add(side, new List<string>());
                    }

                    if (!data[side].Contains(user))
                    {
                        data[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }


                }

                input = Console.ReadLine();
            }


            foreach (var kvp in data.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {

                if (kvp.Value.Count != 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var user in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }

            }

        }
    }
}

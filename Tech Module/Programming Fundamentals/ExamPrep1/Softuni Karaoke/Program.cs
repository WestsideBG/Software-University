using System;
using System.Collections.Generic;
using System.Linq;

namespace Softuni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] songs = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<string, int>> all = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "dawn")
            {
                string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string song = tokens[1];
                string award = tokens[2];


                if (!names.Contains(name) || !songs.Contains(song))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!all.ContainsKey(name))
                {
                    all.Add(name, new Dictionary<string, int>());
                }

                if (!all[name].ContainsKey(award))
                {
                    all[name].Add(award, 1);
                }

                input = Console.ReadLine();
            }

           if (all.Count == 0)
            {
                Console.WriteLine("No awards");

            }
           else
            {
                foreach (var singer in all.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{singer.Key}: {singer.Value.Values.Sum()} awards");
                    foreach (var prize in singer.Value.OrderBy(x => x.Key))
                    {
                        Console.WriteLine($"--{prize.Key}");
                    }
                }
            }
        }
    }
}

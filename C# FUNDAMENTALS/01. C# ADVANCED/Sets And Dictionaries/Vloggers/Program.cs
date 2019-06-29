using System;
using System.Collections.Generic;
using System.Linq;

namespace Vloggers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();


            while (input != "Statistics")
            {
                string[] elements = input.Split();

                string userName = elements[0];
                string command = elements[1];
                string targetUserName = elements[2];

                bool isSameName = userName == targetUserName;

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(userName))
                    {
                        vloggers.Add(userName, new Dictionary<string, SortedSet<string>>());
                        vloggers[userName].Add("followers", new SortedSet<string>());
                        vloggers[userName].Add("following", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    if (vloggers.ContainsKey(userName) && vloggers.ContainsKey(targetUserName) && !isSameName)
                    {
                        vloggers[targetUserName]["followers"].Add(userName);
                        vloggers[userName]["following"].Add(targetUserName);
                    }
                }


                input = Console.ReadLine();
            }


            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count);

            int counter = 1;

            foreach (var vlogger in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }


                counter++;

            }


        }
    }
}

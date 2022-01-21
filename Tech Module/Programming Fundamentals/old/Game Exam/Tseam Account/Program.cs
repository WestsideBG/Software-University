using System;
using System.Collections.Generic;
using System.Linq;

namespace Tseam_Account
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> acc = new List<string>();

            string[] games = input.Split();

            for (int i = 0; i < games.Length; i++)
            {
                acc.Add(games[i]);
            }

            while (input != "Play!")
            {

                input = Console.ReadLine();

                string[] command = input.Split();

                if (command[0] == "Install")
                {
                    if(!acc.Contains(command[1]))
                    acc.Add(command[1]);
                }
                else if (command[0] == "Uninstall")

                {
                    if (acc.Contains(command[1]))
                    acc.Remove(command[1]);
                }
                else if (command[0] == "Expansion")
                {
                    string[] expansion = command[1].Split('-').Select(p => p.Trim()).ToArray();

                    if (acc.Contains(expansion[0]))
                    {
                        int index = acc.IndexOf(expansion[0]);
                        acc.Insert(index + 1, expansion[0] + ":"+ expansion[1].ToString());
                    }

                }
                else if (command[0] == "Update")
                {
                    if (acc.Contains(command[1]))
                    {
                        acc.Remove(command[1]);
                        acc.Add(command[1]);
                    }
                }
                
            }

            
            Console.WriteLine(string.Join(" ", acc));
        }

        
        }
}



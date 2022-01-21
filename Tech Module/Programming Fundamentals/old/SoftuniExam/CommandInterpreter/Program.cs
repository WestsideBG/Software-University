using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
            List<string> currList = new List<string>();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                if (commands[0] == "reverse")
                {
                    
                    int start = int.Parse(commands[2]);
                    int count = int.Parse(commands[4]);

                    if (start < 0 || count < 0 || start >= input.Count || (count + start) > input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        commands = Console.ReadLine().Split();
                        continue;
                    }

                        input.Reverse(start, count);
                }
                else if (commands[0] == "sort")
                {
                    int start = int.Parse(commands[2]);
                    int count = int.Parse(commands[4]);

                    if (start < 0  || count < 0 || start >= input.Count || (count + start) > input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        commands = Console.ReadLine().Split();
                        continue;
                    }

                    currList = input
                                .Skip(start)
                                .Take(count)
                                .OrderBy(str => str)
                                .ToList();

                    input.RemoveRange(start, count);
                    input.InsertRange(start,currList);
                }
                else if (commands[0] == "rollLeft")
                {
                    int count = int.Parse(commands[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        commands = Console.ReadLine().Split();
                        continue;
                    }

                    for (int i = 0; i < count % input.Count; i++)
                    {
                        string element = input[0];
                        input.RemoveAt(0);
                        input.Add(element);
                    }
                }
                else if (commands[0] == "rollRight")
                {
                    int count = int.Parse(commands[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        commands = Console.ReadLine().Split();
                        continue;
                    }

                    for (int i = 0; i < count % input.Count; i++)
                    {
                        string element = input[input.Count-1];
                        input.RemoveAt(input.Count - 1);
                        input.Insert(0,element);
                    }
                }

                commands = Console.ReadLine().Split();
            }



            string output = string.Join(", ", input);
            Console.WriteLine($"[{output}]");


        }
    }
}

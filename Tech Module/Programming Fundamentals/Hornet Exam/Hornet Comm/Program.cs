using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            string broadcastPattern = @"^([^0-9]+) <-> ([A-Z-a-z0-9]+)$";
            string messagePattern = @"^([0-9]+) <-> ([A-Z-a-z0-9]+)$";

            List<string> messageList = new List<string>();
            List<string> broadcast = new List<string>();


            string input = Console.ReadLine();


            while (input != "Hornet is Green")
            {
                Match messageMatch = Regex.Match(input, messagePattern);
                Match broadcastMatch = Regex.Match(input, broadcastPattern);

                if (messageMatch.Success)
                {
                    string code = string.Join("",messageMatch.Groups[1].Value.ToString().Reverse());
                    string message = messageMatch.Groups[2].Value;
                    messageList.Add(code + " -> " + message);
                }

                if (broadcastMatch.Success)
                {
                    string code = broadcastMatch.Groups[1].Value;
                    string message = broadcastMatch.Groups[2].Value;
                    string freqency = "";

                    for (int i = 0; i < message.Length; i++)
                    {
                        if (char.IsUpper(message[i]))
                        {
                            freqency += message[i].ToString().ToLower();
                        }
                        else
                        {
                            freqency += message[i].ToString().ToUpper();
                        }
                    }

                    broadcast.Add(freqency + " -> " + code);

                }

                input = Console.ReadLine();

            }

            Console.WriteLine("Broadcasts:");
            if (broadcast.Count > 0)
                Console.WriteLine(string.Join("\n", broadcast));
            else
                Console.WriteLine("None");

            Console.WriteLine("Messages:");
            if (messageList.Count > 0)
                Console.WriteLine(string.Join("\n", messageList));
            else
                Console.WriteLine("None");
        }
    }
}

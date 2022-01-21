using System;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string jackpotPattern = @"(\${20,20}|@{20,20}|\^{20,20}|#{20,20})";
            string matchPattern = @"(\${6,}|@{6,}|\^{6,}|#{6,})";

            foreach (var ticket in input)
            {

                if (ticket.Length < 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    string leftHalf = ticket.Substring(0, 10);
                    string rightHalf = ticket.Substring(10);

                    if (Regex.IsMatch(ticket,jackpotPattern))
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - 10{ticket[0]} Jackpot!");
                    }
                    else if (Regex.IsMatch(leftHalf,matchPattern) && Regex.IsMatch(rightHalf,matchPattern))
                    {
                        char[] currentMatch = Regex.Match(leftHalf, matchPattern).ToString().ToCharArray();

                        Match leftMatch = Regex.Match(leftHalf, matchPattern);
                        Match rightMatch = Regex.Match(rightHalf, matchPattern);


                        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftMatch.Length,rightMatch.Length)}{currentMatch[0]}");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}

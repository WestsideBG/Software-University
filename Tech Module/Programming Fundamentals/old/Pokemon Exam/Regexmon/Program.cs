using System;
using System.Text.RegularExpressions;

namespace Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string bojoPattern = @"([A-Za-z]+-[A-Za-z]+)";
            string didiPattern = @"([^A-Za-z\-]+)";

            string input = Console.ReadLine();
            int index = 0;
            bool temp = false;

            while (temp != true)
            {
                if (index % 2 == 0)
                {
                    Match didi = Regex.Match(input, didiPattern);
                    if (didi.Success)
                    {
                        string currentValue = didi.Value.ToString();
                        Console.WriteLine(currentValue);
                        int remove = input.IndexOf(currentValue);
                        input = input.Remove(0, currentValue.Length + remove);
                    }
                    else
                    {
                        temp = true;
                    }
                    index++;
                }
                else if (index % 2 != 0)
                {
                    Match bojo = Regex.Match(input, bojoPattern);
                    if (bojo.Success)
                    {
                        string currentValue = bojo.Value.ToString();
                        Console.WriteLine(currentValue);
                        int remove = input.IndexOf(currentValue);
                        input = input.Remove(0, currentValue.Length + remove);
                    }
                    else
                    {
                        temp = true;
                    }
                    index++;
                }
                
            }

        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace ExtractSentences
{
    class ExtractSentences
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string[] text = Console.ReadLine().Split("!.?".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"[^A-Za-z0-9]+";

            foreach (var sentence in text)
            {
                var words = Regex.Split(sentence, pattern);

                foreach (var word in words)
                {
                    if (word == key)
                    {
                        Console.WriteLine(sentence.Trim());
                    }
                }

            }



        }
    }
}

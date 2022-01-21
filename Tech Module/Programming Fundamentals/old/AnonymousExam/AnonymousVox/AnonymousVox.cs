using System;
using System.Text.RegularExpressions;

namespace AnonymousVox
{
    class AnonymousVox
    {
        static void Main(string[] args)
        {
            string encodedText = Console.ReadLine();
            string pattern = @"([A-Za-z]+)(.+)(\1)";
            string[] placeholders = Console.ReadLine().Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            MatchCollection matches = Regex.Matches(encodedText, pattern);

            int count = 0;

            foreach (Match match in matches)
            {
                string decodedText = match.Groups[1] + placeholders[count++] + match.Groups[3];

                encodedText = encodedText.Replace(match.Value, decodedText);
            }

            Console.WriteLine(encodedText);
        }
    }
}

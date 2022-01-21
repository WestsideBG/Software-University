using System;
using System.Text.RegularExpressions;

namespace RegEx
{
    class MatchEmails
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(^| )[a-zA-Z0-9]([\w.-]+\@[a-zA-Z-]+)(\.[a-zA-Z]+)+";

            MatchCollection matchEmails = Regex.Matches(text, pattern);

            foreach (Match email in matchEmails)
            {
                string emailToStr = email.ToString();

                //bool isValid = emailToStr.StartsWith('.') || emailToStr.StartsWith('-') || emailToStr.StartsWith('_') || emailToStr.EndsWith('.') || emailToStr.EndsWith('-') || emailToStr.EndsWith('_');

                //if (!isValid)
                //{
                Console.WriteLine(emailToStr);
                //}
            }

        }
    }
}
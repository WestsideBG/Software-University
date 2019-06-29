namespace Telephony
{
    using System;

    public class Smartphone : ICall, IBrowse
    {
        public Smartphone()
        {

        }

        public string Browsing(string url)
        {
            for (int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    return "Invalid URL!";
                }
            }

            return $"Browsing: {url}!";
        }

        public string Calling(string number)
        {

            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return "Invalid number!";
                }
            }

            return $"Calling... {number}";
        }
    }
}

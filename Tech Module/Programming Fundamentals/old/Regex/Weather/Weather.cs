using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-Z]{2})(\d+.\d+)([A-z]+)\|";

            string input = Console.ReadLine();

            Dictionary<string, CityInfo> cities = new Dictionary<string, CityInfo>();

            while (input != "end")
            {
                var match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string cityName = match.Groups[1].ToString();
                    double avgTemp = double.Parse(match.Groups[2].ToString());
                    string weatherType = match.Groups[3].ToString();

                    CityInfo cityInfo = new CityInfo(avgTemp,weatherType);
                    cities[cityName] = cityInfo;

                }

                input = Console.ReadLine();
            }

            foreach (var city in cities.OrderBy(c => c.Value.AvgTemp))
            {
                Console.WriteLine($"{city.Key} => {city.Value.AvgTemp:F2} => {city.Value.WeatherType}");
            }

        }
    }

     class CityInfo
    {
        public double AvgTemp { get; set; }
        public string WeatherType { get; set; }

        public CityInfo(double averageTemp, string type)
        {
            AvgTemp = averageTemp;
            WeatherType = type;
        }
    }
}

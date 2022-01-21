using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            while (input != "thetinggoesskrra")
            {
                string[] splitedData = input.Split(" ->|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (splitedData.Length > 1)
                {
                    string dataKey = splitedData[0];
                    long dataSize = long.Parse(splitedData[1]);
                    string dataSet = splitedData[2];

                    if (!data.ContainsKey(dataSet))
                    {
                        data.Add(dataSet, new Dictionary<string, long>());
                    }

                    data[dataSet][dataKey] = dataSize;
                }

                input = Console.ReadLine();
            }

            if (data.Count > 1)
            {
                var maxSize = data.OrderByDescending(x => x.Value.Sum(d => d.Value)).First();

                long sum = maxSize.Value.Values.Sum();

                Console.WriteLine($"Data Set: {maxSize.Key}, Total Size: {sum}");

                foreach (var key in maxSize.Value)
                {
                    Console.WriteLine($"$.{key.Key}");
                }
            }

        }
    }
}

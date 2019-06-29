using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothes = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string color = clothes[0];
                string[] colorClothes = clothes[1].Split(",").ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < colorClothes.Length; j++)
                {

                    string currentDress = colorClothes[j];

                    if (!wardrobe[color].ContainsKey(currentDress))
                    {
                        wardrobe[color].Add(currentDress, 0);
                    }

                    wardrobe[color][currentDress]++;

                }
            }

            string[] findDress = Console.ReadLine().Split();

            foreach (var color in wardrobe)
            {
                Console.WriteLine(color.Key + " clothes:");

                foreach (var dress in color.Value)
                {
                    if (color.Key == findDress[0] && dress.Key == findDress[1])
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value}");
                    }

                }
            }

        }
    }
}

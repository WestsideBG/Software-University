using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CameraView
{
    class CameraView
    {
        static void Main()
        {

            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string text = Console.ReadLine();

            string pattern = @"\|<(.*?)(?=\||$)";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> camera = new List<string>();

            foreach (Match match in matches)
            {
                string element = string.Concat(match.Groups[1].ToString().Skip(elements[0]).Take(elements[1]));

                camera.Add(element);
            }

            Console.WriteLine(string.Join(", ", camera));


            //LINQ

            //int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();


            //Console.WriteLine(string.Join(", ", Regex.Matches(Console.ReadLine(), @"\|<(.*?)(?=\||$)")
            //    .Cast<Match>()
            //    .Select(e => string.Concat(e.Groups[1].ToString().Skip(elements[0])
            //    .Take(elements[1]).ToArray()))));



        }
    }
}
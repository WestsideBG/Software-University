using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            GetCounter(out int rectanglesCount, out int intersectionCheks);
            Rectangles(rectangles, rectanglesCount);
            Intersections(rectangles, intersectionCheks);
        }

        private static void GetCounter(out int rectanglesCount, out int intersectionCheks)
        {
            int[] count = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rectanglesCount = count[0];
            intersectionCheks = count[1];
        }

        private static void Rectangles(List<Rectangle> rectangles, int rectanglesCount)
        {
            for (int i = 0; i < rectanglesCount; i++)
            {
                string[] currentRectangle = Console.ReadLine().Split();
                string id = currentRectangle[0];
                int width = int.Parse(currentRectangle[1]);
                int height = int.Parse(currentRectangle[2]);
                int x = int.Parse(currentRectangle[3]);
                int y = int.Parse(currentRectangle[4]);

                rectangles[i] = new Rectangle(id, width, height, x, y);
            }
        }

        private static void Intersections(List<Rectangle> rectangles, int intersectionCheks)
        {
            for (int i = 0; i < intersectionCheks; i++)
            {
                string[] intersectionArgs = Console.ReadLine().Split();
                string firstRectangleId = intersectionArgs[0];
                string secondRectangleId = intersectionArgs[1];

                Rectangle firstRectangle = rectangles.FirstOrDefault(x => x.Id == firstRectangleId);
                Rectangle secondRectangle = rectangles.FirstOrDefault(x => x.Id == secondRectangleId);
                Print(firstRectangle, secondRectangle);
            }
        }

        private static void Print(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (firstRectangle.Intersect(secondRectangle))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}


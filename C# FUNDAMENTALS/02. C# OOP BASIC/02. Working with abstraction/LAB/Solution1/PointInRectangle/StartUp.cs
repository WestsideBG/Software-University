using System;
using System.Linq;

namespace WorkingWithAbstraction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            int topLeftX = coordinates[0];
            int topLeftY = coordinates[1];
            int bottomRightX = coordinates[2];
            int bottomRightY = coordinates[3];


            Rectangle rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);

            for (int i = 0; i < n; i++)
            {
                int[] pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int topLeft = pointCoordinates[0];
                int bottomRight = pointCoordinates[1];
                Point point = new Point(topLeft, bottomRight);

                bool isInside = rectangle.Contains(point);
                Console.WriteLine(isInside);
            }

        }
    }
}

namespace Methods__Debugging_and_Troubleshooting_Code
{
    using System;

    internal class CenterPoint
    {
        internal void Run()
        {
            double[] coords = GetCoords();
            double[] center = GetCenterFromCoords(coords);
            PrintOutput(center);
        }

        private void PrintOutput(double[] center)
        {
            Console.Write("The closest point to the center is: ");
            Console.WriteLine(string.Join(", ", center));
        }

        private double[] GetCenterFromCoords(double[] coords)
        {
            double x1 = coords[0];
            double x2 = coords[1];
            double y1 = coords[2];
            double y2 = coords[3];
            double first = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            double second = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (first < second)
            {
                return new double[] { x1, y1 };
            }
            else
            {
                return new double[] { x2, y2 };
            }
        }

        private double[] GetCoords()
        {
            Console.WriteLine("This method will return the point that is closest to the center of the coordinate system.");
            Console.WriteLine("Please provide the coordinates of two points on a Cartesian coordinate system - X1, Y1, X2 and Y2.");
            double x1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            return new double[] {x1, x2, y1 ,y2};
        }
    }
}
using System;

namespace Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public string Draw()
        {
            return $"Circle Perimeter: {CalculatePerimeter()}{Environment.NewLine}Circle Area: {CalculateArea()}";
        }
    }
}
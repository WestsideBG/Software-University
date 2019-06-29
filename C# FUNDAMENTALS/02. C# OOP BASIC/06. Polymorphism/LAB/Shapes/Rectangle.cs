using System;

namespace Shapes
{
    public class Rectangle : IShape
    {
        private double lenght;
        private double width;

        public Rectangle(double lenght, double width)
        {
            this.Lenght = lenght;
            this.width = width;
        }

        public double Width
        {
            get { return width; }
            private set { width = value; }
        }

        public double Lenght
        {
            get { return lenght; }
            private set { lenght = value; }
        }



        public double CalculatePerimeter()
        {
            return 2 * (width + lenght);
        }

        public double CalculateArea()
        {
            return width * lenght;
        }

        public string Draw()
        {
            return $"Rectangle Perimeter: {CalculatePerimeter()}{Environment.NewLine}Rectangle Area: {CalculateArea()}";
        }
    }
}
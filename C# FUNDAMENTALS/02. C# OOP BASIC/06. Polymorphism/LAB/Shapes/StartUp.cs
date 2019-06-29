using System;

namespace Shapes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IShape rectangle = new Rectangle(3, 5);
            IShape circle = new Circle(5);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(circle.Draw());
        }
    }
}

namespace WorkingWithAbstraction
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle(int leftX, int leftY, int rightX, int rightY)
        {
            this.TopLeft = new Point(leftX, leftY);
            this.BottomRight = new Point(rightX, rightY);
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal = point.X >= TopLeft.X && BottomRight.X >= point.X;
            bool isInVertical = TopLeft.Y <= point.Y && BottomRight.Y >= point.Y;

            bool isInRectangle = isInHorizontal && isInVertical;

            return isInRectangle;
        }
    }
}

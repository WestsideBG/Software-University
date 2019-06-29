namespace ClassBox
{
    internal class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        private double Lenght
        {
            get { return this.lenght; }
            set
            {
                if (value <= 0)
                {
                    throw new System.Exception("Length cannot be zero or negative.");
                }
                lenght = value;
            }
        }
        private double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new System.Exception("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }
        private double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new System.Exception("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }


        public double GetVolume(Box box)
        {
            return box.lenght * box.width * box.height;
        }

        public double GetLateralSurface(Box box)
        {
            return 2 * (box.lenght * box.height) + 2 * (box.width * box.height);
        }

        public double GetSurface(Box box)
        {
            return 2 * (box.lenght * box.width) + 2 * (box.lenght * box.height) + 2 * (box.width * box.height);
        }
    }
}
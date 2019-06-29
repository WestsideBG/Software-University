namespace Ferrari.Car
{
    public class Ferrari : ICar
    {
        private const string model = "488-Spider";

        public Ferrari(string driver)
        {
            Driver = driver;
            Model = model;
        }

        public string Model { get; private set; }
        public string Driver { get; private set ; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{Model}/{Brakes()}/{Gas()}/{Driver}";
        }
    }
}

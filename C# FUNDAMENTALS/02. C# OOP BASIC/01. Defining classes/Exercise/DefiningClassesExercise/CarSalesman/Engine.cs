namespace CarSalesman
{
    internal class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string engineModel, int enginePower, int displacement, string efficiency)
        {
            this.Model = engineModel;
            this.Power = enginePower;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
    }
}
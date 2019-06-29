namespace SpeedRacing
{
    public class Car
    {
        public double FuelAmmount { get; set; }
        public double FuelConsumtionPerKM { get; set; }
        public int TravelledDistance { get; set; } = 0;

        public Car(int fuelAmmount, double fuelConsumtion)
        {
            this.FuelAmmount = fuelAmmount;
            this.FuelConsumtionPerKM = fuelConsumtion;
        }

        public void Drive(int amountOfKm)
        {
            if (amountOfKm * FuelConsumtionPerKM <= FuelAmmount)
            {
                this.TravelledDistance += amountOfKm;
                this.FuelAmmount -= amountOfKm * FuelConsumtionPerKM;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}

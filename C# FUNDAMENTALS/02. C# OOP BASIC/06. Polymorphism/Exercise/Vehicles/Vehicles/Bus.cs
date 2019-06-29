using System;

namespace Vehicles.Vehicles
{
    public class Bus : Vehicle
    {
        private const double airConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double distance)
        {
            double currentFuelConsumption = this.FuelConsumption;

            if (!IsEmpty)
            {
                currentFuelConsumption += airConditionConsumption;
            }

            var neededFuel = currentFuelConsumption * distance;

            if (this.FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededFuel;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
    }
}
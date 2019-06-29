using System;

namespace Vehicles.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; }
        public bool IsEmpty { get; set; }   

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public virtual void Drive(double distance)
        {

            var neededFuel = FuelConsumption * distance;

            if (this.FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= neededFuel;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            if (this is Truck)
            {
                fuel *= 0.95;
            }

            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
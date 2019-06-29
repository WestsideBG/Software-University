﻿namespace Vehicles.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }
        bool IsEmpty { get; set; }

        void Drive(double distance);
        void Refuel(double fuel);
    }
}
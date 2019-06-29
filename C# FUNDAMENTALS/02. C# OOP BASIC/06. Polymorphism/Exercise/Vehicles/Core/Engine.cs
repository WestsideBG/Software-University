using System;
using System.Dynamic;
using Vehicles.Vehicles;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carArgs = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);
            double carTankCapacity = double.Parse(carArgs[3]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckArgs = Console.ReadLine().Split();

            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);
            double truckTankCapacity = double.Parse(truckArgs[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busArgs = Console.ReadLine().Split();

            double busFuelQuantity = double.Parse(busArgs[1]);
            double busFuelConsumption = double.Parse(busArgs[2]);
            double busTankQuantity = double.Parse(busArgs[3]);

            Vehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankQuantity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] actionArgs = Console.ReadLine().Split();

                    string action = actionArgs[0];
                    string type = actionArgs[1];
                    double value = double.Parse(actionArgs[2]);

                    if (action == "Drive")
                    {
                        if (type == "Car")
                        {
                            car.Drive(value);
                        }
                        else if (type == "Truck")
                        {
                            truck.Drive(value);
                        }
                        else
                        {
                            bus.Drive(value);
                        }

                    }
                    else if (action == "Refuel")
                    {
                        if (type == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else
                        {
                            bus.Refuel(value);
                        }
                    }
                    else
                    {
                        bus.IsEmpty = true;
                        bus.Drive(value);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
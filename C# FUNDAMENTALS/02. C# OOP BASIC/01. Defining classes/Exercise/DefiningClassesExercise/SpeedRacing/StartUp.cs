using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> allCars = new Dictionary<string, Car>();
            StoreCars(n, allCars);
            DriveCars(allCars);
            PrintCars(allCars);
        }

        private static void PrintCars(Dictionary<string, Car> allCars)
        {
            foreach (var model in allCars)
            {
                Console.WriteLine($"{model.Key} {model.Value.FuelAmmount:F2} {model.Value.TravelledDistance}");
            }
        }

        private static void DriveCars(Dictionary<string, Car> allCars)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();
                string model = commandArgs[1];
                int km = int.Parse(commandArgs[2]);

                if (allCars.ContainsKey(model))
                {
                    allCars[model].Drive(km);
                }

            }
        }

        private static void StoreCars(int n, Dictionary<string, Car> allCars)
        {
            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split();
                string model = carArgs[0];
                int fuelAmmount = int.Parse(carArgs[1]);
                double fuelConsumption = double.Parse(carArgs[2]);

                if (!allCars.ContainsKey(model))
                {
                    allCars.Add(model, new Car(fuelAmmount, fuelConsumption));
                }
            }
        }
    }
}

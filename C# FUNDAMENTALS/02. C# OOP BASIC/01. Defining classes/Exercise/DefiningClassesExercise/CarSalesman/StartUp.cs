using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            GetEngine(engines);
            GetCars(cars, engines);
            Print(cars);
        }

        private static void GetEngine(List<Engine> engines)
        {
            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] currentEngine = Console.ReadLine().Trim().Split();
                string engineModel = currentEngine[0];
                int enginePower = int.Parse(currentEngine[1]);
                int displacement = 0;
                string efficiency = "n/a";

                if (currentEngine.Length == 3)
                {
                    if (int.TryParse(currentEngine[2], out int result))
                    {
                        displacement = result;
                    }
                    else
                    {
                        efficiency = currentEngine[2];
                    }
                }
                else if (currentEngine.Length == 4)
                {
                    displacement = int.Parse(currentEngine[2]);
                    efficiency = currentEngine[3];
                }
                Engine engine = new Engine(engineModel, enginePower, displacement, efficiency);
                engines.Add(engine);
            }
        }

        private static void GetCars(List<Car> cars, List<Engine> engines)
        {
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] currentCar = Console.ReadLine().Trim().Split();
                string model = currentCar[0];
                string engineModel = currentCar[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
                int weight = 0;
                string color = "n/a";

                if (currentCar.Length == 3)
                {
                    if (int.TryParse(currentCar[2], out int result))
                    {
                        weight = result;
                    }
                    else
                    {
                        color = currentCar[2];
                    }
                }
                else if (currentCar.Length == 4)
                {
                    weight = int.Parse(currentCar[2]);
                    color = currentCar[3];
                }

                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }
        }

        private static void Print(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"  Power: {car.Engine.Power}");
                if (car.Engine.Displacement == 0)
                {
                    Console.WriteLine("  Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"  Displacement: {car.Engine.Displacement}");
                }
                Console.WriteLine($"  Efficiency: {car.Engine.Efficiency}");
                if (car.Weight == 0)
                {
                    Console.WriteLine(" Weight: n/a");
                }
                else
                {
                    Console.WriteLine($" Weight: {car.Weight}");
                }

                Console.WriteLine($" Color: {car.Color}");
            }
        }
    }
}

namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            StoreCars(n, allCars);
            PrintCars(allCars);

        }

        private static void PrintCars(List<Car> allCars)
        {
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragileCars = allCars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                                                  .Select(x => x.Model)
                                                  .ToList();
                Console.WriteLine(String.Join(Environment.NewLine, fragileCars));
            }
            else
            {
                List<string> flamable = allCars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                                              .Select(x => x.Model)
                                              .ToList();
                Console.WriteLine(String.Join(Environment.NewLine, flamable));
            }
        }

        private static void StoreCars(int n, List<Car> cars)
        {
            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split();
                string model = carArgs[0];
                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);
                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];

                List<Tire> tires = new List<Tire>();

                for (int j = 0; j < 4; j++)
                {
                    double currentTirePressure = double.Parse(carArgs[5]);
                    int currentTireAge = int.Parse(carArgs[6]);

                    Tire tire = new Tire(currentTireAge, currentTirePressure);
                    tires.Add(tire);

                }
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                InputDataProccesing(cars);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                Fragile(cars);
            }
            else
            {
                Flamble(cars);
            }
        }

        private static void InputDataProccesing(List<Car> cars)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            List<Tire> tires = new List<Tire>();

            
            for (int j = 0; j < 4; j++)
            {
                double currentTirePressure = double.Parse(parameters[5 + j]);
                int currentTireAge = int.Parse(parameters[6 + j]);
                Tire tire = new Tire(currentTireAge,currentTirePressure);
                tires.Add(tire);

            }

            Engine engine = new Engine(engineSpeed,enginePower);
            Cargo cargo = new Cargo(cargoWeight,cargoType);
            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        private static void Flamble(List<Car> cars)
        {
            List<string> flamable = cars
                .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamable));
        }

        private static void Fragile(List<Car> cars)
        {
            List<string> fragile = cars
                                .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure< 1))
                                .Select(x => x.Model)
                                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }
    }
}

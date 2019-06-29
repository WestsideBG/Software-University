using Farm.Animals;
using Farm.Factories;
using System;
using System.Collections.Generic;

namespace Farm.Core
{
    public class Engine
    {
        private AnimalFactory animalFactory;
        private List<Animal> animals;
        public Engine()
        {
            animalFactory = new AnimalFactory();
            animals = new List<Animal>();
        }


        public void Run()
        {
            string beastCommand;

            while ((beastCommand = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string type = beastCommand;
                    string[] animalArgs = Console.ReadLine().Split();
                    string name = animalArgs[0];
                    int age = int.Parse(animalArgs[1]);
                    string gender = animalArgs[2];
                    Animal currentAnimal = animalFactory.CreateAnimal(type, name, age, gender);
                    animals.Add(currentAnimal);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Print();
        }


        public void Print()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                animal.ProduceSound();

            }
        }
    }
}

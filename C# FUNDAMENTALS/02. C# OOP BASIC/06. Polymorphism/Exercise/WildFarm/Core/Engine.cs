using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds.Factory;
using WildFarm.Animals.Mammals.Factory;
using WildFarm.Animals.Mammals.Felines.Factory;
using WildFarm.Foods.Factory;

namespace WildFarm.Core
{
    public class Engine
    {
        private BirdFactory birdFactory;
        private MammalFactory mammalFactory;
        private FelineFactory felineFactory;
        private FoodFactory foodFactory;
        private List<Animal> animals;
        private Animal animal;

        public Engine()
        {
            this.birdFactory = new BirdFactory();
            this.mammalFactory = new MammalFactory();
            this.felineFactory = new FelineFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                
                string[] animalArgs = input.Split();
                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double animalWeight = double.Parse(animalArgs[2]);

                if (animalType == "Hen" || animalType == "Owl")
                {
                    double wingSize = double.Parse(animalArgs[3]);
                    animal = birdFactory.CreateBird(animalType, animalName, animalWeight, wingSize);
                }
                else if (animalType == "Dog" || animalType == "Mouse")
                {
                    string livingRegion = animalArgs[3];
                    animal = mammalFactory.CreateMammal(animalType, animalName, animalWeight, livingRegion);
                }
                else if (animalType == "Cat" || animalType == "Tiger")
                {
                    string livingRegion = animalArgs[3];
                    string breed = animalArgs[4];
                    animal = felineFactory.CreateFeline(animalType, animalName, animalWeight, livingRegion, breed);
                }

                string[] foodArgs = Console.ReadLine().Split();
                string foodType = foodArgs[0];
                int quantity = int.Parse(foodArgs[1]);

                var food = foodFactory.CreateFood(foodType, quantity);


                animal.ProduceSound();
                animal.Eat(food);
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
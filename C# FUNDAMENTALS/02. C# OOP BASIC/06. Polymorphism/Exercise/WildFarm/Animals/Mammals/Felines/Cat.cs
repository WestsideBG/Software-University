using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double WeightIncrease = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                this.Weight += food.Quantity * WeightIncrease;
                this.FoodEaten += food.Quantity;

            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
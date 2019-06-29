using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WeightIncrease = 0.35;

        public Hen(string name, double weight,  double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * WeightIncrease;
            this.FoodEaten += food.Quantity;
        }
    }
}
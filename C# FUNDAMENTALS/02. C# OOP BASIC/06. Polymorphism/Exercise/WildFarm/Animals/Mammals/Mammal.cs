﻿namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $", {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
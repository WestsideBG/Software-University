namespace WildFarm.Animals.Mammals.Felines
{
    public abstract class Feline : Animal,IFeline
    {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight)
        {
            LivingRegion = livingRegion;
            Breed = breed;
        }

        public string LivingRegion { get; private set; }
        public string Breed { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $", {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
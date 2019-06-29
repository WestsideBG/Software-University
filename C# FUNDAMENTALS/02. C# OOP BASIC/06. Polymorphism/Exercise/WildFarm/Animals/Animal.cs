using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract void ProduceSound();
        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}";
        }
    }
}
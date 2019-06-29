using System;

namespace Animals
{
    public class Cat : IAnimal
    {

        public Cat(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavoriteFood = favoriteFood;
        }

        public string Name { get; }
        public string FavoriteFood { get; }


        public string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is {FavoriteFood}{Environment.NewLine}MEEOW";
        }
    }
}
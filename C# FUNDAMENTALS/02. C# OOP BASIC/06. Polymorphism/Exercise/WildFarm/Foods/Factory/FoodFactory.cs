using System;

namespace WildFarm.Foods.Factory
{
    public class FoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            type = type.ToLower();

            switch (type)
            {
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                case "fruit":
                    return new Fruit(quantity);
                case "vegetable":
                    return new Vegetable(quantity);
                default:
                    return null;
            }
        }
    }
}
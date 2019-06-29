namespace PizzaCalories
{
    public class Topping
    {
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private int Weight
        {
            get { return weight; }
            set
            {
                if (value <= 0 || value > 50)
                {
                    throw new System.Exception($"{this.Type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }
        private string Type
        {
            get { return type; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                                        && value.ToLower() != "cheese" 
                                        && value.ToLower() != "sauce")
                {
                    throw new System.Exception($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
         
        public double CalculateCalories()
        {
            double modifier = 0;
            switch (this.Type.ToLower())
            {
                case "meat":
                    modifier = meat;
                    break;
                case "veggies":
                    modifier = veggies;
                    break;
                case "cheese":
                    modifier = cheese;
                    break;
                case "sauce":
                    modifier = sauce;
                    break;
            }

            return (this.Weight * 2) * modifier;
        }
    }
}

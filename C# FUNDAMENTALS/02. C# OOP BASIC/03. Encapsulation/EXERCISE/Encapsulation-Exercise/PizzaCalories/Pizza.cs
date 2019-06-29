namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private List<Topping> toppings;


        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public Dough Dough { get; set; }
        private string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new System.Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        } 

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }
        public double Calories()
        {
            double sum = 0;
            sum += this.Dough.Calories;
            this.toppings.ForEach(c => sum += c.CalculateCalories());
            return sum;
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories():F2} Calories.";
        }

        
    }
}

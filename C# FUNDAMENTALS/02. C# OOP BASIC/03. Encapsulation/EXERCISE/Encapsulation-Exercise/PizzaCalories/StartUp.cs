namespace PizzaCalories
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {

            string[] pizzaArgs = Console.ReadLine().Split();
            string name = pizzaArgs[1];

            try
            {
                Pizza pizza = new Pizza(name);

                string[] doughArgs = Console.ReadLine().Split();
                string flour = doughArgs[1];
                string doughBaking = doughArgs[2];
                int doughWeight = int.Parse(doughArgs[3]);

                Dough dough = new Dough(flour, doughBaking, doughWeight);
                pizza.Dough = dough;
                string endChecker;
                while ((endChecker = Console.ReadLine()) != "END")
                {
                    string[] toppingArgs = endChecker.Split();
                    string toppingType = toppingArgs[1];
                    int toppingWeight = int.Parse(toppingArgs[2]);


                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                }

                Console.WriteLine(pizza.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }


        }
    }
}

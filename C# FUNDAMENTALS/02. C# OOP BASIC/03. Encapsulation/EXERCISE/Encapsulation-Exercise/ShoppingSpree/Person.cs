using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.products = new List<Product>();
            this.Money = money;
            this.Name = name;
        }

        public List<Product> Products { get => products;}
        private string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        private decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Price)
            {
                throw new Exception($"{this.Name} can't afford {product.Name}");
            }

            this.Products.Add(product);
            this.Money -= product.Price;
        }
    }
}

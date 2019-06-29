namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Money cannot be negative");
                }
                price = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.Exception("Name cannot be empty");
                }

                name = value;
            }
        }

    }
}
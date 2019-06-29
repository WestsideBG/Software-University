namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> clients = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] clientsArgs = Console.ReadLine().Split(';');
            GetClients(clients, clientsArgs);

            string[] productsArgs = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            GetProducts(products, productsArgs);
            BuyProducts(clients, products);
            Print(clients);
        }

        private static void Print(Dictionary<string, Person> clients)
        {
            foreach (var client in clients)
            {
                List<string> productsName = client.Value.Products.Select(p => p.Name).ToList();
                if (productsName.Count > 0)
                {
                    Console.WriteLine($"{client.Key} - {string.Join(", ", productsName)}");
                }
                else
                {
                    Console.WriteLine($"{client.Key} - Nothing bought");
                }
            }
        }

        private static void BuyProducts(Dictionary<string, Person> clients, Dictionary<string, Product> products)
        {
            string buyCommand;
            while ((buyCommand = Console.ReadLine()) != "END")
            {
                string[] buyCommandArgs = buyCommand.Split();
                string buyer = buyCommandArgs[0];
                string product = buyCommandArgs[1];

                try
                {
                    if (clients.ContainsKey(buyer) && products.ContainsKey(product))
                    {
                        clients[buyer].BuyProduct(products[product]);
                    }
                    Console.WriteLine($"{buyer} bought {product}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void GetProducts(Dictionary<string, Product> products, string[] productsArgs)
        {
            for (int i = 0; i < productsArgs.Length; i++)
            {
                string[] currentProduct = productsArgs[i].Split('=');
                string productName = currentProduct[0];
                decimal productPrice = decimal.Parse(currentProduct[1]);

                try
                {
                    if (!products.ContainsKey(productName))
                    {
                        products.Add(productName, new Product(productName, productPrice));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        private static void GetClients(Dictionary<string, Person> clients, string[] clientsArgs)
        {
            for (int i = 0; i < clientsArgs.Length; i++)
            {
                string[] currentClient = clientsArgs[i].Split('=');
                string clientName = currentClient[0];
                decimal clientMoney = decimal.Parse(currentClient[1]);

                try
                {
                    if (!clients.ContainsKey(clientName))
                    {
                        clients.Add(clientName, new Person(clientName, clientMoney));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}

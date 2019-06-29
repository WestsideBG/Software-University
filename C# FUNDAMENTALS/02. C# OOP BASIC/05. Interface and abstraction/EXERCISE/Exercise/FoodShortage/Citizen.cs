namespace BorderControl
{

    public class Citizen : ICitizen, IBuyer
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public int Food { get; private set; }

        public Citizen(string name, int age,string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}

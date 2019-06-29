using System;

namespace Animals
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IAnimal cat = new Cat("Gosho", "Whiskas");
            IAnimal dog = new Dog("Pesho", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}

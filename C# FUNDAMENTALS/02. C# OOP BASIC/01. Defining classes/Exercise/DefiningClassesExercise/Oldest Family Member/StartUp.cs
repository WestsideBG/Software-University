namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine().Split();
                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);
                family.AddMember(new Person(name, age));
                
            }

            Person oldestPerson = family.GetOldestPerson();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

        }
    }
}

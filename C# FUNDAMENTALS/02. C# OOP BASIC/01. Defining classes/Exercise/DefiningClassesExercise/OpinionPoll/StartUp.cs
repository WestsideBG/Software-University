using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> adults = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currPerson = Console.ReadLine().Split();
                string name = currPerson[0];
                int age = int.Parse(currPerson[1]);

                Person person = new Person(name, age);

                if (age > 30)
                {
                    adults.Add(person);
                }
            }

            foreach (var adult in adults.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{adult.Name} - {adult.Age}");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedByName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> sortedByAge = new SortedSet<Person>(new AgeComparator());

            int n = int.Parse(Console.ReadLine());

            while (n-- != 0)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                Person person = new Person(name, age);
                sortedByAge.Add(person);
                sortedByName.Add(person);
            }

            Console.WriteLine(String.Join(Environment.NewLine,sortedByName));
            Console.WriteLine(String.Join(Environment.NewLine,sortedByAge));
        }
    }
}

using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();
                string name = args[0];
                int age = int.Parse(args[1]);
                string town = args[2];

                Person person = new Person(name,age,town);
                people.Add(person);
            }

            var comparePerson = people[int.Parse(Console.ReadLine()) - 1];

            int equalNum = 0;
            int notEqualNum = 0;

            foreach (var person in people)
            {

                int result = comparePerson.CompareTo(person);

                if (result == 0)
                {
                    equalNum++;
                }
                else
                {
                    notEqualNum++;
                }

            }

            if (equalNum > 1)
            {
                Console.WriteLine($"{equalNum} {notEqualNum} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }
    }
}

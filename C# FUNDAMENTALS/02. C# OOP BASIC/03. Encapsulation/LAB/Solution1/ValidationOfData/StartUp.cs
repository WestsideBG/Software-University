using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();
            Team team = new Team("Team");
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string firstName = cmdArgs[0];
                string lastName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                decimal salary = decimal.Parse(cmdArgs[3]);

                try
                {
                    Person person = new Person(firstName, lastName, age, salary);
                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team.ToString());
        }
    }
}

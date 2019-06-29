namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Citizen> citizens = new HashSet<Citizen>();
            HashSet<Rebel> rebels = new HashSet<Rebel>();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                if (cmdArgs.Length == 4)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    string birthdate = cmdArgs[3];

                    Citizen citizen = new Citizen(name, age, id);
                    citizens.Add(citizen);
                }
                else
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string group = cmdArgs[2];

                    Rebel rebel = new Rebel(name, age, group);
                    rebels.Add(rebel);
                }
            }

            string command;
            int allFood = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                string name = command;

                foreach (var citizen in citizens)
                {
                    if (citizen.Name == name)
                    {
                        citizen.BuyFood();
                        allFood += 10;
                    }
                }

                foreach (var rebel in rebels)
                {
                    if (rebel.Name == name)
                    {
                        rebel.BuyFood();
                        allFood += 5;
                    }
                }
            }
                Console.WriteLine(allFood);
        }
    }
}

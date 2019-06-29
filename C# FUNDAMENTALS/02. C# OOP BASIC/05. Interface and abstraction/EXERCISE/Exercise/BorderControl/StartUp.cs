using System;
using System.Collections.Generic;

namespace BorderControl
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //List<string[]> input = new List<string[]>();
            //string command;

            //while ((command = Console.ReadLine()) != "End")
            //{
            //    string[] cmdArgs = command.Split();

            //    input.Add(cmdArgs);     
            //}

            //string year = Console.ReadLine();

            //foreach (var item in input)
            //{

            //    if (item[0] == "Citizen")
            //    {
            //        string name = item[1];
            //        int age = int.Parse(item[2]);
            //        string id = item[3];
            //        string birthdate = item[4];

            //        Citizen citizen = new Citizen(name, age, id, year,birthdate);
            //    }
            //    else if (item[0] == "Pet")
            //    {
            //        string name = item[1];
            //        string birthdate = item[2];

            //        Pet pet = new Pet(name, birthdate, year);
            //    }



            //}

            List<int> numbers = new List<int>();
            int number = 1;
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            numbers.Add(number++);
            int seventhNumber = numbers[6];
            Console.WriteLine(seventhNumber);
        }
    }
}

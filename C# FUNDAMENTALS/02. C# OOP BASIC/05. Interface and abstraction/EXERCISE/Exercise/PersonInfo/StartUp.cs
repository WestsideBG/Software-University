namespace PersonInfo
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IPerson person = new Citizen(name, age,id,birthdate);
            Console.WriteLine(person.ToString());
        }
    }
}

namespace GenericBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> messages = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                messages.Add(message);
            }
            string item = Console.ReadLine();

            Box<string> box = new Box<string>(messages);
            int result = box.Compare(item);
            Console.WriteLine(result);



        }
    }
}

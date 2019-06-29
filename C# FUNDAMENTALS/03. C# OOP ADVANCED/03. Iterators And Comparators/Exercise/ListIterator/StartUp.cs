using System;
using System.Linq;

namespace ListIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();

            ListIterator<string> list = new ListIterator<string>(elements.Skip(1).ToArray());

            string input = Console.ReadLine();

            while (input != "END")
            {

                switch (input)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(list.Print());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ",list));
                        break;
                }


                input = Console.ReadLine();
            }


        }
    }
}

using System.Linq;

namespace Stack
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

                if (elements[0] == "Push")
                {
                    foreach (var element in elements.Skip(1))
                    {                    
                        stack.Push(element);
                    }
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));


        }
    }
}

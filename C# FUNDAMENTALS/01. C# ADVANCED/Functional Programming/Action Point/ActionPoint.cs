using System;

namespace Action_Point
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string[]> action = Print;

            action(input);
        }

        private static void Print(string[] array)
        {
            Console.WriteLine(string.Join(Environment.NewLine,array));
        }
    }
}

using System;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> action = col => Console.WriteLine(string.Join(Environment.NewLine, col.Select(n => $"Sir {n}")));
            action(input);
        }

    }
}

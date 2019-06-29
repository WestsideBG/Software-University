using System;

namespace Predicate_For_Names
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine().Split();

            Func<string, bool> predicate = s => s.Length <= n;

            for (int i = 0; i < inputNames.Length; i++)
            {
                if (predicate(inputNames[i]))
                {
                    Console.WriteLine(inputNames[i]);
                }
            }
        }
    }
}

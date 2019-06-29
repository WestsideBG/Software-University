using System.Linq;

namespace Froggy
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Lake lake = new Lake(array);
            
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}

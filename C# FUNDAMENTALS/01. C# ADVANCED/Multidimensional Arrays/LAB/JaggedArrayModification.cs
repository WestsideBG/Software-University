using System;
using System.Linq;

namespace JaggedArrayModification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggArr = new int[n][];

            for (int i = 0; i < jaggArr.Length; i++)
            {
                jaggArr[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string[] commands = Console.ReadLine().Split().ToArray();



            while (commands[0] != "END")
            {
                string command = commands[0];
                int row = 0;
                int col = 0;
                int value = 0;
                if (commands.Length > 1)
                {
                    row = int.Parse(commands[1]);
                    col = int.Parse(commands[2]);
                    value = int.Parse(commands[3]);
                }

                if (row < 0 || row > jaggArr.Length - 1 || col < 0 || col > jaggArr[row].Length)
                {
                    Console.WriteLine("Invalid coordinates!");
                    commands = Console.ReadLine().Split().ToArray();
                    continue;
                }

                switch (command.ToLower())
                {
                    case "add":
                        jaggArr[row][col] += value;
                        break;
                    case "subtract":
                        jaggArr[row][col] -= value;
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine().Split().ToArray();
            }

            foreach (int[] arr in jaggArr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}

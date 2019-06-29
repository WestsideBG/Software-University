using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();

            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = dimensions[0];
            int col = dimensions[1];

            string input = Console.ReadLine();

            while (input != "stop")
            {
                int[] commands = input.Split().Select(int.Parse).ToArray();

                int entryRow = commands[0];
                int targetRow = commands[1];
                int targetCol = commands[2];


                if (!IsFree(parking, targetRow, targetCol))
                {
                    ParkCar(parking, targetRow, targetCol);
                    int distance = Math.Abs(entryRow - targetRow);
                    distance += targetCol + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    targetCol = FindEmptySpace(parking[targetRow], col, targetCol);
                    if (targetCol == 0)
                    {
                        Console.WriteLine($"Row {targetRow} full");
                    }
                    else
                    {
                        ParkCar(parking, targetRow, targetCol);
                        int distance = Math.Abs(entryRow - targetRow);
                        distance += targetCol + 1;
                        Console.WriteLine(distance);
                    }
                }


                input = Console.ReadLine();
            }


        }

        private static int FindEmptySpace(HashSet<int> hashSet, int col, int targetCol)
        {
            int targetColIndex = 0;
            int minDistance = int.MaxValue;
            if (hashSet.Count == col - 1)
            {
                return targetColIndex;
            }
            else
            {
                for (int i = 1; i < col; i++)
                {
                    int currentDistance = Math.Abs(targetCol - 1);

                    if (!hashSet.Contains(i) && currentDistance < minDistance)
                    {
                        targetColIndex = i;
                        minDistance = currentDistance;
                    }
                }
            }

            return targetColIndex;
        }

        private static void ParkCar(Dictionary<int, HashSet<int>> parking, int targetRow, int targetCol)
        {
            if (!parking.ContainsKey(targetRow))
            {
                parking.Add(targetRow, new HashSet<int>());
            }

            parking[targetRow].Add(targetCol);
        }

        private static bool IsFree(Dictionary<int, HashSet<int>> parking, int targetRow, int targetCol)
        {
            return parking.ContainsKey(targetRow) && parking[targetRow].Contains(targetCol);
        }
    }
}

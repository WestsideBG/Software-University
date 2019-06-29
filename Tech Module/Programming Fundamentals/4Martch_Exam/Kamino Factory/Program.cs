using System;
using System.Linq;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int[] bestSq = new int[lenght];
            int counter = 1;
            int currLenght = 0;
            int currIndex = 0;
            int bestLenght = 0;
            int bestIndex = 0;
            int indexOfSeq = 0;

            while (input != "Clone them!")
            {
                int[] arr = input.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 1)
                    {
                        currLenght++;
                        if (currLenght > bestLenght)
                        {
                            indexOfSeq = counter;
                            bestLenght = currLenght;
                            bestSq = arr;
                            bestIndex = Array.IndexOf(arr, i - currLenght);
                        }
                        else if (currLenght == bestIndex)
                        {
                            if (currIndex == bestIndex)
                            {
                                int sumBest = bestSq.Sum();
                                int currentSum = arr.Sum();

                                if (currentSum > sumBest)
                                {
                                    indexOfSeq = counter;
                                    bestLenght = currLenght;
                                    bestSq = arr;
                                    bestIndex = Array.IndexOf(arr, i - currLenght);
                                }
                            }
                            else
                            {
                                if (currIndex > bestIndex)
                                {
                                    indexOfSeq = counter;
                                    bestLenght = currLenght;
                                    bestSq = arr;
                                    bestIndex = Array.IndexOf(arr, i - currLenght);
                                }
                            }
                        }

                    }
                    else
                    {
                        currLenght = 0;
                        currIndex = 0;
                    }

                }

                counter++;

                input = Console.ReadLine();
            }


            Console.WriteLine(indexOfSeq + " " + bestSq.Sum());
            Console.WriteLine(string.Join(" ",bestSq));
        }
    }
}

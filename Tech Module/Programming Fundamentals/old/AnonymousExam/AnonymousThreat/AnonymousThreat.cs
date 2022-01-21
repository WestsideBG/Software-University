using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dataInput = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] currentCommand = input.Split();

                string command = currentCommand[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(currentCommand[1]);
                    int endIndex = int.Parse(currentCommand[2]);

                    startIndex = validateIndex(startIndex, dataInput.Count);
                    endIndex = validateIndex(endIndex, dataInput.Count);

                    string concatted = "";

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatted += dataInput[i];
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        dataInput.RemoveAt(startIndex);
                    }

                    dataInput.Insert(startIndex, concatted);

                }
                else if (command == "divide")
                {
                    int index = int.Parse(currentCommand[1]);
                    int partition = int.Parse(currentCommand[2]);

                    List<string> divided = DivideIndex(dataInput[index], partition);
                    dataInput.RemoveAt(index);
                    dataInput.InsertRange(index, divided);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", dataInput));

        }

        private static List<string> DivideIndex(string word, int partition)
        {
            List<string> result = new List<string>();
            int part = word.Length / partition;

            while (word.Length >= part)
            {
                result.Add(word.Substring(0, part));
                word = word.Substring(part);
            }

            if (word != "")
            {
                result.Add(word);
            }

            if (result.Count == partition)
            {
                return result;
            }
            else
            {
                string concatLastElements = result[result.Count - 2] + result[result.Count - 1];
                result.RemoveRange(result.Count - 2, 2);
                result.Add(concatLastElements);
                return result;
            }

        }

        private static int validateIndex(int index, int count)
        {
            if (index < 0)
            {
                index = 0;
            }
            
            if (index > count - 1)
            {
                index = count - 1;
            }
            return index;
        }
    }
}

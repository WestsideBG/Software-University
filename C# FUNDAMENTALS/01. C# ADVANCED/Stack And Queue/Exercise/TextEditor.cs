using System;
using System.Collections.Generic;

namespace Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                int command = int.Parse(input[0]);

                if (command == 1)
                {
                    string currentText = input[1];
                    stack.Push(text);
                    
                    text += currentText;
                }
                else if (command == 2)
                {
                    int count = int.Parse(input[1]);
                    stack.Push(text);
                    text = text.Substring(0, text.Length - count);
                }
                else if (command == 3)
                {
                    int index = int.Parse(input[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else if (command == 4)
                {
                    text = stack.Pop();
                }

            }


        }
    }
}

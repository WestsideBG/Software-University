using System;
using System.Collections.Generic;

namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    brackets.Push(input[i]);
                }

                if (input[i] == '}')
                {
                    if (brackets.Count > 0)
                    {
                        if (brackets.Peek() == '{')
                        {
                            brackets.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == ']')
                {
                    if (brackets.Count > 0)
                    {
                        if (brackets.Peek() == '[')
                        {
                            brackets.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == ')')
                {
                    if (brackets.Count > 0)
                    {
                        if (brackets.Peek() == '(')
                        {
                            brackets.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                
            }

            if (brackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}


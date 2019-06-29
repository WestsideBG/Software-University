using System;
using System.Collections.Generic;
using System.Text;

namespace Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> master = new Queue<string>();
            Queue<string> knight = new Queue<string>();
            Queue<string> padawan = new Queue<string>();
            Queue<string> specialPadawan = new Queue<string>();

            bool isYodaExist = false;

            for (int i = 0; i < n; i++)
            {
                string[] jedi = Console.ReadLine().Split();

                for (int j = 0; j < jedi.Length; j++)
                {

                    char currentJedi = jedi[j][0];

                    if (currentJedi == 'm')
                    {
                        master.Enqueue(jedi[j] + " ");
                    }
                    else if (currentJedi == 'k')
                    {
                        knight.Enqueue(jedi[j] + " ");
                    }
                    else if (currentJedi == 'p')
                    {
                        padawan.Enqueue(jedi[j] + " ");
                    }
                    else if (currentJedi == 's' || currentJedi == 't')
                    {
                        specialPadawan.Enqueue(jedi[j] + " ");
                    }
                    else if (currentJedi == 'y')
                    {
                        isYodaExist = true;
                    }
                }
            }

            if (isYodaExist)
            {
                StringBuilder output = new StringBuilder();

                output.Append(string.Join("", master));
                output.Append(string.Join("", knight));
                output.Append(string.Join("", specialPadawan));
                output.Append(string.Join("", padawan));

                Console.WriteLine(output);

            }
            else
            {
                StringBuilder output = new StringBuilder();

                output.Append(string.Join("", specialPadawan));
                output.Append(string.Join("", master));
                output.Append(string.Join("", knight));
                output.Append(string.Join("", padawan));

                Console.WriteLine(output);
            }

        }
    }
}

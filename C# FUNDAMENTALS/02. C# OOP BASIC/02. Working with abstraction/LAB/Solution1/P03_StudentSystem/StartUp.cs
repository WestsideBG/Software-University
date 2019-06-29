using System;
namespace P03_StudentSystem
{
    public class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                string[] args = Console.ReadLine().Split();

                if (args[0] == "Create")
                {
                    studentSystem.Create(args);
                }
                else if (args[0] == "Show")
                {
                    studentSystem.Show(args);

                }
                else if (args[0] == "Exit")
                {
                    studentSystem.Exit();
                }

            }
        }

    }
}


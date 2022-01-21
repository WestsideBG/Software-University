using System.Collections.Generic;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class Exercise
    {
        public string Name { get; set; }
        public void Run(string name, List<Exercise> exercises)
        {
            if (this.Name.Contains("Hello,Name"))
            {
                System.Console.WriteLine($"Hello, {name}");
                StartUp.ReturnOrExit(name,exercises);
            }
            else if (this.Name.Contains("Max Method"))
            {
                MaxMethod exercise = new MaxMethod();
                exercise.Run();
                StartUp.ReturnOrExit(name, exercises);
            }
            else if (this.Name.Contains("English Name оf the Last Digit"))
            {
                EnglishName exercise = new EnglishName();
                exercise.Run();
                StartUp.ReturnOrExit(name, exercises);
            }
            else
            {
                System.Console.WriteLine("im here");
                System.Console.WriteLine("The input is incorrect. Try Again.");
                StartUp.GetExcersise(name, exercises);
            }
        }

        public Exercise(string name)
        {
            this.Name = name;
        }
    }
}
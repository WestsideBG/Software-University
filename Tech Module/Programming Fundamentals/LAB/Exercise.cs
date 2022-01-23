namespace Methods__Debugging_and_Troubleshooting_Code
{
    using System.Collections.Generic;

    internal class Exercise
    {
        public string Name { get; set; }

        public string Type { get; set; }

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
            else if (this.Name.Contains("Reversed Order"))
            {
                ReversedOrder exercise = new ReversedOrder();
                exercise.Run();
                StartUp.ReturnOrExit(name, exercises);
            }
            else if (this.Name.Contains("Fibonacci"))
            {
                Fibonacci exercise = new Fibonacci();
                exercise.Run();
                StartUp.ReturnOrExit(name, exercises);
            }
            else if (this.Name.Contains("Prime Checker"))
            {
                PrimeCalculator exercise = new PrimeCalculator();
                exercise.Run(name,false);
                StartUp.ReturnOrExit(name, exercises);
            }
            else if (this.Name.Contains("Primes in Given Range"))
            {
                PrimeCalculator exercise = new PrimeCalculator();
                exercise.Run(name,true);
                StartUp.ReturnOrExit(name, exercises);
            }
            else if (this.Name.Contains("Center Point"))
            {
                CenterPoint exercise = new CenterPoint();
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

        public Exercise(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
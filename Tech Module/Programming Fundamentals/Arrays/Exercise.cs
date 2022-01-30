namespace Methods__Debugging_and_Troubleshooting_Code
{
    using System;
    using System.Collections.Generic;
    internal class Exercise
    {
        public Exercise(string name, string type)
        {
            this.Name = name;
        }

        public string Name { get; internal set; }

        internal void Run(string name, List<Exercise> exercises)
        {
            if (this.Name.Contains("Reverse an Array of Integers"))
            {
                ReverseArray exercise = new ReverseArray();
                exercise.Run();
                StartUp.ReturnOrExit(name, exercises);
            }
        }
    }
}
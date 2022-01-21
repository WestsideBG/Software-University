namespace Methods__Debugging_and_Troubleshooting_Code
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public string Name { get; set; } 
        static void Main(string[] args)
        {
            List<Exercise> exercises = new List<Exercise>();
            var HelloName = new Exercise("01.Hello,Name");
            var MaxMethod = new Exercise("02.Max Method");
            var EnglishName = new Exercise("03.English Name оf the Last Digit");
            exercises.Add(HelloName);
            exercises.Add(MaxMethod);
            exercises.Add(EnglishName);
            PrintIntroduction();
            string name = GetName();
            PrintExercises(name, exercises);

        }

        internal static void ReturnOrExit(string name, List<Exercise> exercises)
        {
            Console.WriteLine("The exercise is completed succesfully!");
            Console.WriteLine("Do you want to continiue? [Y/N]");
            string exitorno = Console.ReadLine();
            if (exitorno == "Y")
            {
                GetExcersise(name, exercises);
            }
            else
            {
                SayGoodBye(name);
            }
        }

        private static void PrintExercises(string name, List<Exercise> exercises)
        {
            Console.WriteLine($"Nice to meet you, {name}!");
            Console.WriteLine("Do you want to see my exercises ?");
            Console.WriteLine("Type [Y/N]");
            string yesorno = Console.ReadLine();
            if (yesorno == "Y")
            {
                foreach (var exercise in exercises)
                {
                    Console.WriteLine(exercise.Name);
                }
                GetExcersise(name,exercises);
            }
            else
            {
                SayGoodBye(name);
            }
        }

        private static void SayGoodBye(string name)
        {
            Console.WriteLine($"It was an honor for me to meet you! Good Bye {name}!");
        }

        public static string GetName()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            return name;
        }

        private static void PrintIntroduction()
        {
            Console.WriteLine("Welcome to my exercise program! My name is Samir Azzam and I'm a software engineer.");
        }

        internal static void GetExcersise(string name, List<Exercise> exercises)
        {
            Console.WriteLine("Provide the number of the exercise which you want to see.");
            string exerciseNum = Console.ReadLine();
            RunExercise(name, exerciseNum, exercises);
        }

        private static void RunExercise(string name, string exerciseNum, List<Exercise> exercises)
        {
            bool isTrue = false;
            foreach (var exercise in exercises)
            {
                if (exercise.Name.Contains(exerciseNum))
                {
                    exercise.Run(name, exercises);
                    isTrue = true;
                }
            }

            if (!isTrue)
            {
                Console.WriteLine("The input is incorrect. Try Again.");
                GetExcersise(name, exercises);
            }
            isTrue = false;
        }
    }
}

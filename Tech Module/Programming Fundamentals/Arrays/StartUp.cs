﻿namespace Methods__Debugging_and_Troubleshooting_Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = GetName();
            Console.WriteLine($"Nice to meet you, {name}!");
            Console.WriteLine("Welcome to my exercise program! My name is Samir Azzam and I'm a software engineer.");

            bool run = RunOrNot();

            if (run)
            {
                Run(name);
            }
            else
            {
                SayGoodBye(name);
            }
        }

        private static void Run(string name)
        {
            string type = GetType();
            if (type == null)
            {
                return;
            }
            List<Exercise> exercises = CreateExercises(type);
            PrintExercises(name, exercises);
            string exerciseNum = GetExcersise(name, exercises);
            RunExercise(name, exerciseNum, exercises);
        }

        private static List<Exercise> CreateExercises(string type)
        {
            List<Exercise> exercises = new List<Exercise>();
            if (type.Contains("2"))
            {
                string Lab = "Exercises";
                
            }
            else if (type.Contains("1"))
            {
                string Lab = "LAB";
                var ReverseArray = new Exercise("01.Reverse an Array of Integers", Lab);
                exercises.Add(ReverseArray);
            }
            return exercises;
        }

        internal static void ReturnOrExit(string name, List<Exercise> exercises)
        {
            Console.WriteLine("The exercise is completed succesfully!");
            Console.WriteLine("Do you want to continiue? [Y/N]");
            string exitorno = Console.ReadLine();
            if (exitorno == "Y" || exitorno == "y")
            {
                Run(name);
            }
            else
            {
                SayGoodBye(name);
            }
        }

        private static void PrintExercises(string name, List<Exercise> exercises)
        {

            foreach (var exercise in exercises)
            {
                Console.WriteLine(exercise.Name);
            }
        }

        internal static void SayGoodBye(string name)
        {

            Console.WriteLine($"It was an honor for me to meet you! Good Bye {name}!");
        }

        internal static string GetName()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            return name;
        }

        private static bool RunOrNot()
        {

            Console.WriteLine("Do you want to see my exercises ?");
            Console.WriteLine("Type [Y/N]");

            string yesorno = Console.ReadLine();

            if (yesorno == "Y" || yesorno == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static string GetType()
        {
            Console.WriteLine("Please, select a type by providing a number:");
            Console.WriteLine("01.Lab");
            Console.WriteLine("02.Exercises");
            string type = Console.ReadLine();
            return type;
        }

        internal static string GetExcersise(string name, List<Exercise> exercises)
        {
            Console.WriteLine("Provide the number of the exercise which you want to see.");
            string exerciseNum = Console.ReadLine();
            return exerciseNum;
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
        }
    }
}

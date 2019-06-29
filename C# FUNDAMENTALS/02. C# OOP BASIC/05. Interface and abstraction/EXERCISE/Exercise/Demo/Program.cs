using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int allowedbadGrades = int.Parse(Console.ReadLine());

            int badGrades = 0;
            int solutions = 0;
            double averageScore = 0;
            string lastProblem = null;


            while (allowedbadGrades > 0)
            {
                string problemName = Console.ReadLine();
                int grade = int.Parse(Console.ReadLine());
                solutions++;
                averageScore += grade;

                if (grade <= 4)
                {
                    badGrades--;
                }
                if (allowedbadGrades == 0)
                {
                    Console.WriteLine($"You need a break, {badGrades} poor grades.");
                    return;
                }

                if (problemName == "Enough")

                {
                    lastProblem += problemName;
                    break;
                }


            }
            Console.WriteLine($"Average score: {averageScore / solutions}");
            Console.WriteLine($"Number of problems: {solutions}");
            Console.WriteLine($"Last problem {lastProblem}");

        }
    }
}
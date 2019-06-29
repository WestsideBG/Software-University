using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> allContests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> allStudents = new Dictionary<string, Dictionary<string, int>>();


            string contest = Console.ReadLine();

            while (contest != "end of contests")
            {
                string[] contestInfo = contest.Split(':');
                string contestName = contestInfo[0];
                string contestPassword = contestInfo[1];

                if (!allContests.ContainsKey(contestName))
                {
                    allContests.Add(contestName, contestPassword);
                }

                contest = Console.ReadLine();
            }

            string students = Console.ReadLine();
            string bestCandidate = string.Empty;
            int candidatePoints = 0;

            while (students != "end of submissions")
            {
                string[] studentsInfo = students.Split("=>");

                string contestName = studentsInfo[0];
                string contestPassword = studentsInfo[1];
                string studentName = studentsInfo[2];
                int studentPoints = int.Parse(studentsInfo[3]);

                if (allContests.ContainsKey(contestName) && allContests[contestName] == contestPassword)
                {
                    
                    if (!allStudents.ContainsKey(studentName))
                    {
                        allStudents.Add(studentName, new Dictionary<string, int>());                       
                    }

                    if (!allStudents[studentName].ContainsKey(contestName))
                    {
                        allStudents[studentName].Add(contestName, studentPoints);

                    }

                    if (studentPoints > allStudents[studentName][contestName])
                    {
                        allStudents[studentName][contestName] = studentPoints;
                    }
                }
                students = Console.ReadLine();
            }

            foreach (var student in allStudents)
            {
                int currentPoints = 0;

                foreach (var points in student.Value)
                {
                    currentPoints += points.Value;
                    if (currentPoints > candidatePoints)
                    {
                        candidatePoints = currentPoints;
                        bestCandidate = student.Key;
                    }
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {candidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in allStudents.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var contests in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contests.Key} -> {contests.Value}");
                }
            }
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                employees.Add(InputDataProcessing());
            }

            var topDepartment = employees.GroupBy(x => x.Department)
                                         .ToDictionary(x => x.Key, y => y.Select(s => s))
                                         .OrderByDescending(x => x.Value.Average(s => s.Salary))
                                         .FirstOrDefault();

            Print(topDepartment);

        }

        private static void Print(KeyValuePair<string, IEnumerable<Employee>> topDepartment)
        {
            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (var employee in topDepartment.Value)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary} {employee.Email} {employee.Age}");
            }
        }

        private static Employee InputDataProcessing()
        {

            string[] employeeArgs = Console.ReadLine().Split();
            string name = employeeArgs[0];
            decimal salary = decimal.Parse(employeeArgs[1]);
            string position = employeeArgs[2];
            string department = employeeArgs[3];
            string email = "n/a";
            int age = -1;

            if (employeeArgs.Length == 5)
            {
                if (employeeArgs[4].Contains("@"))
                {
                    email = employeeArgs[4];
                }
                else
                {
                    age = int.Parse(employeeArgs[4]);
                }
            }
            else if (employeeArgs.Length == 6)
            {
                if (employeeArgs[4].Contains("@"))
                {
                    email = employeeArgs[4];
                    age = int.Parse(employeeArgs[5]);
                }
                else
                {
                    email = employeeArgs[5];
                    age = int.Parse(employeeArgs[4]);
                }
            }

            Employee employee = new Employee(name, salary, position, department, email, age);

            return employee;

        }
    }
}

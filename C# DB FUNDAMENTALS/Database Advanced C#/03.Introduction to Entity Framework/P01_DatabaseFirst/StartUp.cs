using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            using (SoftUniContext context = new SoftUniContext())
            {
                //P03
                //string result = GetEmployeesFullInformation(context);

                //P04
                //string result = GetEmployeesWithSalaryOver50000(context);


                //P05
                //string result = GetEmployeesFromResearchAndDevelopment(context);

                //P06
                //string result = AddNewAddressToEmployee(context);

                //P07
                //string result = GetEmployeesInPeriod(context);

                //P08
                //string result = GetAddressesByTown(context);

                //P09
                //string result = GetEmployee147(context);

                //P10
                //string result = GetDepartmentsWithMoreThan5Employees(context);

                //P11
                //string result = GetLatestProjects(context);

                //P12
                //string result = IncreaseSalaries(context);

                //P13
                //string result = GetEmployeesByFirstNameStartingWithSa(context);

                //P14
                //string result = DeleteProjectById(context);

                //P15
                string result = RemoveTown(context);
                Console.WriteLine(result);

                List<string> list = Console.ReadLine().Split('|').ToList();

            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }


            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(e => new
            {
                e.FirstName,

                e.Salary
            })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Department.Name,
                e.Salary
            })
                .Where(e => e.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            nakov.Address = newAddress;

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine(address);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(p =>
                    p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    }).ToList()
                })
                .Take(10);


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.Projects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = project.EndDate.HasValue 
                        ?
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        :
                        "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => new
                {
                    Town = x.Town.Name,
                    Address = x.AddressText,
                    Employees = x.Employees.Count
                })
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.Address}, {address.Town} - {address.Employees} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emp = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.
                        Select(ep => ep.Project.Name)
                        .OrderBy(p => p)
                        .ToList()
                }).FirstOrDefault();


            sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");

            foreach (var project in emp.Projects)
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var deps = context.Departments
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                })
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.DepartmentName)
                .ToList();

            foreach (var dep in deps)
            {
                sb.AppendLine($"{dep.DepartmentName} - {dep.ManagerFullName}");

                foreach (var employee in dep.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();

            foreach (var project in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
                
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                          || e.Department.Name == "Tool Design"
                          || e.Department.Name == "Marketing"
                          || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)

        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
                .Where(e => EF.Functions.Like(e.FirstName,"Sa%"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)

                .ToList();


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var project = context
                .Projects
                .FirstOrDefault(p => p.ProjectId == 2);

            var employeeProjects = context.EmployeesProjects
                .Where(p => p.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(employeeProjects);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => new {p.Name})
                .Take(10)
                .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
            }

            

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            string townName = "Seattle";

            context.Employees
                .Where(e => e.Address.Town.Name == townName)
                .ToList()
                .ForEach(e => e.AddressId = null);

            int adressesCount = context.Addresses.Count(a => a.Town.Name == townName);

            context.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList()
                .ForEach(a => context.Addresses.Remove(a));

            var town = context.Towns.FirstOrDefault(t => t.Name == townName);

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{adressesCount} addresses in {townName} were deleted";
        }
    }
}

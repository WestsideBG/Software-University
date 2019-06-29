using System;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new StudentSystemContext())
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();

                //SeedStudent(context);
                Console.WriteLine("You are registered successfully");
            }
        }

        private static void SeedStudent(StudentSystemContext context)
        {
            Console.WriteLine("Register student:");
            Console.WriteLine("Enter your full name:");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter your phone number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter your birthday:");
            Console.WriteLine("If you do not want to issue this personal information, press 'n'");
            string birthdayInString = Console.ReadLine();
            DateTime birthday = default(DateTime);
            if (birthdayInString != "n")
            {
                birthday = Convert.ToDateTime(birthdayInString);
            }

            var student = new Student()
            {
                Name = studentName,
                PhoneNumber = phoneNumber,
                Birthday = birthday
            };

            context.Students.Add(student);

            context.SaveChanges();
        }
    }
}

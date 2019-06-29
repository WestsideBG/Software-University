namespace Mankind
{
    using System;
    using System.Text;

    class StartUp
    {
        public static void Main(string[] args)
        {

            string[] studentArgs = Console.ReadLine().Split();
            string studentFirstName = studentArgs[0];
            string studentLastName = studentArgs[1];
            string facultyNumber = studentArgs[2];

            string[] workerArgs = Console.ReadLine().Split();
            string workerFirstName = workerArgs[0];
            string workerLastName = workerArgs[1];
            double salaryPerWeek = double.Parse(workerArgs[2]);
            double hoursPerDay = double.Parse(workerArgs[3]);

            StringBuilder output = new StringBuilder();

            try
            {
                Student student = new Student(studentFirstName, studentLastName, facultyNumber);

                output.AppendLine(student.ToString());
                output.AppendLine();

                Worker worker = new Worker(workerFirstName, workerLastName, salaryPerWeek, hoursPerDay);

                output.AppendLine(worker.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}

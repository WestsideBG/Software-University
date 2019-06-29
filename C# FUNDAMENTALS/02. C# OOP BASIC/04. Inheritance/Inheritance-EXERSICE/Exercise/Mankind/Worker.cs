namespace Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double salary, double hours) : base(firstName, lastName)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = hours;
        }

        public double SalaryPerHour { get; set; }

        public double WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }
                workHoursPerDay = value;
            }
        }

        public double WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }

                weekSalary = value;
            }
        }

        private double CalcSalary()
        {
            double salary = this.WeekSalary / 5 / this.workHoursPerDay;
            return salary;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());

            result.AppendLine(string.Format(
                "Week Salary: {0:F2}", this.WeekSalary));
            result.AppendLine(string.Format(
                "Hours per day: {0:F2}", this.WorkHoursPerDay));
            result.AppendLine(string.Format(
                "Salary per hour: {0:F2}", this.CalcSalary()));

            return result.ToString().Trim();
        }
    }
}

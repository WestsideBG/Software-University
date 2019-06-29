namespace Mankind
{
    using System;
    using System.Text;

    public class Student : Human
    {
        private string facultyNumber;


        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {

                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetterOrDigit(value[i]) || value.Length < 5 || value.Length > 10)
                    {
                        throw new ArgumentException("Invalid faculty number!");
                    }
                }

                facultyNumber = value;
            }
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());

            result.AppendLine(string.Format(
                "Faculty number: {0}", this.FacultyNumber));

            return result.ToString().Trim();
        }
    }
}

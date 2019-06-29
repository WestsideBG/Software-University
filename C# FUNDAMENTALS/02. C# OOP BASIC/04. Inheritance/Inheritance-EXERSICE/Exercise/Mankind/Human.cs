namespace Mankind
{
    using System;
    using System.Text;

    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: firstName");
                }

                if (value.Length <= 3)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: lastName");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
                }

                lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format(
                "First Name: {0}", this.FirstName));
            result.AppendLine(string.Format(
                "Last Name: {0}", this.LastName));

            return result.ToString();
        }
    }
}
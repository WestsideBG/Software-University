namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private decimal salary;
        private int age;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Age = age;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public int Age { get => age; set => age = value; }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age > 30)
            {
                Salary += Salary * (percentage / 100);
            }
            else
            {
                Salary += Salary * (percentage / 200);
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}

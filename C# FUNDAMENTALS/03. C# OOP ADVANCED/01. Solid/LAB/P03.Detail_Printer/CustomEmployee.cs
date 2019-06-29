using System;

namespace P03.DetailPrinter
{
    public class CustomEmployee : Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public CustomEmployee(string name,int age) : base(name)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + this.Age;
        }
    }
}
namespace DefiningClasses
{
    public class Person
    {
        private int age;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    
        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
    
    }
}
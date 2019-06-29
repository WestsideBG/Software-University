using System;

namespace BorderControl
{
    public class Citizen : ICitizen
    {
        private string id;
        private string year;
        private string birthdate;



        public Citizen(string name, int age, string id, string year,string birthdate)
        {
            this.year = year;
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Birthdate
        {
            get => birthdate;
            set
            {
                if (value.EndsWith(year))
                {
                    Console.WriteLine(value);
                }

                this.birthdate = value;
            }
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id
        {
            get => this.id;
            private set
            {
                if (value.EndsWith(year))
                {
                    Console.WriteLine(value);
                }

                id = value;
            }
        }
    }
}

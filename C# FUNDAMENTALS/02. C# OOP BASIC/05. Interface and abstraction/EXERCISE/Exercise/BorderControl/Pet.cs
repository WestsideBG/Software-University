namespace BorderControl
{
    public class Pet : IPet
    {
        private string name;
        private string birthdate;
        private string year;

        public Pet(string name, string birthdate, string year)
        {
            this.Name = name;
            this.year = year;
            this.Birthdate = birthdate;
        }

        public string Birthdate
        {
            get { return birthdate; }
            set
            {
                if (value.EndsWith(year))
                {
                    System.Console.WriteLine(value);
                }

                birthdate = value;
            }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}

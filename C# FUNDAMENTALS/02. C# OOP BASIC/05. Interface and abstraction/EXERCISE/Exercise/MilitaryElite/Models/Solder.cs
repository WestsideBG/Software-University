namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;

    public abstract class Solder : ISolder
    {
        protected Solder(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
        }
    }
}
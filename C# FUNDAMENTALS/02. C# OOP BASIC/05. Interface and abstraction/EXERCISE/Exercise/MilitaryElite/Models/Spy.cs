using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Spy : Solder , ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCode Number: {CodeNumber}";
        }
    }
}
namespace StrategyPattern
{
    using System.Collections.Generic;

    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}
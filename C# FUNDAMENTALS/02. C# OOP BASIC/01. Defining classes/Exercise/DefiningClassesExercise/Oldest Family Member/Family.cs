using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyList;

        public List<Person> FamilyList { get { return this.familyList;} set { this.familyList = value;}}

        public Family()
        {
            this.familyList = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.familyList.Add(person);   
        }

        public Person GetOldestPerson()
        {
            return this.FamilyList.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}

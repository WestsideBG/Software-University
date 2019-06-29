namespace PeopleDatabase
{
    public class Person
    {
        public Person(string username, long id)
        {
            Username = username;
            Id = id;
        }

        public string Username { get; private set; }
        public long Id { get; private set; }
    }
}
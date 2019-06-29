namespace PersonInfo
{
    public interface IPerson : IBirthable, IIdentifiable
    {
        string Name { get; set; }
        int Age { get; set; }

    }
}

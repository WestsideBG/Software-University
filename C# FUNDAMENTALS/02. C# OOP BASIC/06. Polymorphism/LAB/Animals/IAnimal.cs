namespace Animals
{
    public interface IAnimal
    {
        string Name { get; }
        string FavoriteFood { get; }

        string ExplainSelf();

    }
}
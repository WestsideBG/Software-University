namespace WildFarm.Animals.Mammals.Felines
{
    public interface IFeline : IAnimal, IMammal
    {
        string Breed { get; }
    }
}
namespace Ferrari.Car
{
   public interface ICar
    {
        string Model { get;  }
        string Driver { get; }

        string Gas();
        string Brakes();
    }
}

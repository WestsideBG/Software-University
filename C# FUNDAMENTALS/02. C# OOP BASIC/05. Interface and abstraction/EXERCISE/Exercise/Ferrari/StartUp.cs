namespace Ferrari
{
    using Ferrari.Car;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            ICar car = new Ferrari(driver);

            Console.WriteLine(car.ToString());

        }
    }
}

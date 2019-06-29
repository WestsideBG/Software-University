using System;
using System.Collections.Generic;

namespace Traffic_Light
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int carsPerGreen = int.Parse(Console.ReadLine());
            string currentCar = Console.ReadLine();
            int passedCars = 0;

            while (currentCar != "end")
            {
                if (currentCar == "green")
                {
                    for (int i = 0; i < carsPerGreen; i++)
                    {
                        if (cars.Count >= 1) 
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCars++;
                        }
                        
                    }
                }
                else
                {
                    cars.Enqueue(currentCar);
                }
                currentCar = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");


        }
    }
}

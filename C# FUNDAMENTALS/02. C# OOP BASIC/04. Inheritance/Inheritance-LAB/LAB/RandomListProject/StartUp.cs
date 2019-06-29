using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("Monday");
            randomList.Add("Thuesday");
            randomList.Add("Wednesday");

            while (randomList.Count > 0)
            Console.WriteLine(randomList.GetRandomString());
        }
    }
}

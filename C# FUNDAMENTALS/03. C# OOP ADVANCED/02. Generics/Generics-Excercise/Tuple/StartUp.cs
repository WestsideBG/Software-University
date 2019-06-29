using System;

namespace Tumple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = personInfo[0] + " " + personInfo[1];
            string town = personInfo[3];
            string adress = personInfo[2];

            string[] beerInfo = Console.ReadLine().Split();
            string name = beerInfo[0];
            int amountOfBeer = int.Parse(beerInfo[1]);
            bool isDrunk = beerInfo[2] == "drunk";


            string[] accountInfo = Console.ReadLine().Split();
            string accountName = accountInfo[0];
            double balance = double.Parse(accountInfo[1]);
            string bankName = accountInfo[2];

            CustomTuple<string, string,string> customTuple = new CustomTuple<string, string, string>(fullName, adress, town);
            CustomTuple<string,int,bool> beerTuple = new CustomTuple<string, int,bool>(name,amountOfBeer, isDrunk);
            CustomTuple<string,double,string> specialTuple = new CustomTuple<string, double,string>(accountName, balance, bankName);

            Console.WriteLine(customTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(specialTuple);
        }
    }
}

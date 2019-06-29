using System;
using System.Collections.Generic;

namespace BankAccountMethods
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> db = new Dictionary<int, BankAccount>();

            string cmdCommand;

            while ((cmdCommand = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmdCommand.Split();

                string command = cmdArgs[0];

                if (command == "Create")
                {
                    Create(db, cmdArgs);
                }
                else if(command == "Deposit")
                {
                    Deposit(db, cmdArgs);
                }
                else if (command == "Withdraw")
                {
                    Withdraw(db, cmdArgs);
                }
                else if(command == "Print")
                {
                    Console.WriteLine(Print(db, cmdArgs)); 
                }

           
            }
        }

        private static string Print(Dictionary<int, BankAccount> db, string[] cmdArgs)
        {
            int id = int.Parse(cmdArgs[1]);
            return db[id].ToString();
        }

        private static void Withdraw(Dictionary<int, BankAccount> db, string[] cmdArgs)
        {
            int id = int.Parse(cmdArgs[1]);
            decimal ammount = decimal.Parse(cmdArgs[2]);
            if (db.ContainsKey(id))
            {
                if (db[id].Balance >= ammount)
                {
                    db[id].Balance -= ammount;
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                }
            }
        }

        private static void Deposit(Dictionary<int, BankAccount> db, string[] cmdArgs)
        {
            int id = int.Parse(cmdArgs[1]);
            decimal ammount = decimal.Parse(cmdArgs[2]);
            if (db.ContainsKey(id))
            {
                db[id].Balance += ammount;
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(Dictionary<int, BankAccount> db, string[] cmdArgs)
        {
            int id = int.Parse(cmdArgs[1]);

            if (!db.ContainsKey(id))
            {
                BankAccount acc = new BankAccount();
                db.Add(id, acc);
                db[id].Id = id;
            }
            else
            {
                Console.WriteLine("Account already exists");
            }
        }
    }
}

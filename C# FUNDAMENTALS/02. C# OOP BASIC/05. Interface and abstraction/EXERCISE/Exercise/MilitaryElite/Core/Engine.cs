using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine
    {
        public void Run()
        {
            ICollection<ISolder> solders = new List<ISolder>();
            ISolder solder = null;

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                string type = cmdArgs[0];
                string id = cmdArgs[1];
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    solder = new Private(id,firstName,lastName,salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);

                    ILieutenantGeneral currentLieutenantGeneral = new LieutenantGeneral(id,firstName,lastName,salary);

                    for (int i = 5; i < cmdArgs.Length; i++)
                    {
                        var currentPrivate = (IPrivate)solders.FirstOrDefault(x => x.Id == cmdArgs[i]);
                        currentLieutenantGeneral.Privates.Add(currentPrivate);
                    }
                    solder = currentLieutenantGeneral;
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corpsAsString = cmdArgs[5];

                    if(!Enum.TryParse(corpsAsString,out Corps corps))
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id,firstName,lastName,salary,corps);

                    for (int i = 6; i < cmdArgs.Length; i+=2)
                    {
                        string partName = cmdArgs[i];
                        int hoursWorked = int.Parse(cmdArgs[i + 1]);

                        IRepair repair = new Repair(partName,hoursWorked);

                        engineer.Repairs.Add(repair);
                    }

                    solder = engineer;
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corpsAsString = cmdArgs[5];

                    if (!Enum.TryParse(corpsAsString, out Corps corps))
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id,firstName,lastName,salary,corps);

                    for (int i = 6; i < cmdArgs.Length; i += 2)
                    {
                        string codeName = cmdArgs[i];
                        string stateAsString = cmdArgs[i + 1];

                        if (!Enum.TryParse(stateAsString, out State state))
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName,state);

                        commando.Missions.Add(mission);
                    }
                    solder = commando;
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);
                    ISpy spy = new Spy(id,firstName,lastName,codeNumber);
                    solder = spy;
                }

                if (solder != null)
                {
                    solders.Add(solder);
                }

            }

            foreach (var soldier in solders)
            {
                Console.WriteLine(soldier);
            }

        }
    }
}
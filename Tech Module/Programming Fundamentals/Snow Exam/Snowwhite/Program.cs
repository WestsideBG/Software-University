using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Program
    {
        // Judge - 60/100
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, decimal>> dwarfs = new Dictionary<string, Dictionary<string, decimal>>();

            while (input != "Once upon a time")
            {

                string[] token = input.Split(" <:>".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = token[0];
                string dwarfHat = token[1];
                decimal physic = decimal.Parse(token[2]);

                if (!dwarfs.ContainsKey(dwarfHat))
                {
                    dwarfs.Add(dwarfHat, new Dictionary<string, decimal>());
                }

                if (!dwarfs[dwarfHat].ContainsKey(dwarfName))
                {
                    dwarfs[dwarfHat].Add(dwarfName, physic);
                }
                else
                {
                    if (dwarfs[dwarfHat][dwarfName] < physic)
                    {
                        dwarfs[dwarfHat][dwarfName] = physic;
                    }
                }


                input = Console.ReadLine();
            }

            foreach (var hat in dwarfs.OrderByDescending(x => x.Value.Values.Max()).ThenByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hat.Value)
                {
                    Console.WriteLine($"({hat.Key}) {dwarf.Key} <-> {dwarf.Value}");
                }
            }
            
        }
    }
}

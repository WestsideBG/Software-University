using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> pokemonsEvolutions = new Dictionary<string, Dictionary<string, int>>();

            while (input != "wubbalubbadubdub")
            {
               
                string[] tokens = input.Split(" -> ");
                if (tokens.Length > 1)
                {
                    string pokemonName = tokens[0];
                    string evolutionType = tokens[1];
                    int evolutionIndex = int.Parse(tokens[2]);

                    if (!pokemonsEvolutions.ContainsKey(pokemonName))
                    {
                        pokemonsEvolutions.Add(pokemonName, new Dictionary<string, int>());
                    }

                    pokemonsEvolutions[pokemonName].Add(evolutionType, evolutionIndex);
                }
                else
                {
                    string pokeName = tokens[0];
                    
                    if (pokemonsEvolutions.ContainsKey(pokeName))
                    {
                        Console.WriteLine($"# {pokemonsEvolutions[pokeName]}");
                        foreach (var evolution in pokemonsEvolutions.Values)
                        {
                            Console.WriteLine(evolution.Keys + " <-> " + evolution.Values);
                        }
                    }

                }
                


                input = Console.ReadLine();
            }


            foreach (var name in pokemonsEvolutions)
            {
                Console.WriteLine($"# {name.Key}");

                foreach (var evolution in name.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine(evolution.Key + " <-> " + evolution.Value);
                    ;
                }
            }

        }
    }
}
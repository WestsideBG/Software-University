using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> pokemons = Console.ReadLine().Split().Select(long.Parse).ToList();

            long count = 0;

            while(pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                long currPokemon = 0;

                if (index < 0)
                {
                    currPokemon = pokemons[0];
                    count += currPokemon;
                    pokemons[0] = pokemons[pokemons.Count - 1];
 
                }
                else if (index > pokemons.Count - 1)
                {
                    currPokemon = pokemons[pokemons.Count - 1];
                    count += currPokemon;
                    pokemons[pokemons.Count - 1] = pokemons[0];
                    
                }
                else
                {
                    currPokemon = pokemons[index];               
                    count += currPokemon;
                    pokemons.RemoveAt(index);
                }

                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= currPokemon)
                    {
                        pokemons[i] += currPokemon;
                    }
                    else
                    {
                        pokemons[i] -= currPokemon;
                    }
                }
            }

            Console.WriteLine(count);

            
        }
    }
}

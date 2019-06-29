namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            GetCatchedPokemon(trainers);
            CheckTrainer(trainers);
            RemoveDiedPokemon(trainers);
            Print(trainers);

        }

        private static void Print(Dictionary<string, Trainer> trainers)
        {
            foreach (var trainer in trainers.Values.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        private static void RemoveDiedPokemon(Dictionary<string, Trainer> trainers)
        {
            foreach (var trainer in trainers.Values)
            {
                for (int i = 0; i < trainer.Pokemons.Count; i++)
                {
                    if (trainer.Pokemons[i].Health <= 0)
                    {
                        trainer.Pokemons.RemoveAt(i);
                        i--;
                    }
                }

            }
        }

        private static void CheckTrainer(Dictionary<string, Trainer> trainers)
        {
            string element = Console.ReadLine();
            while (element != "End")
            {
                foreach (var trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                }

                element = Console.ReadLine();
            }
        }

        private static void GetCatchedPokemon(Dictionary<string, Trainer> trainers)
        {
            string catchedPokemonArgs = Console.ReadLine();

            while (catchedPokemonArgs != "Tournament")
            {
                string[] currentPokemon = catchedPokemonArgs.Split();
                string trainerName = currentPokemon[0];
                string pokemonName = currentPokemon[1];
                string pokemonElement = currentPokemon[2];
                int pokemontHealth = int.Parse(currentPokemon[3]);
                Trainer trainer = new Trainer(trainerName);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, trainer);
                }
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemontHealth);
                trainers[trainerName].Pokemons.Add(pokemon);

                catchedPokemonArgs = Console.ReadLine();
            }
        }
    }
}

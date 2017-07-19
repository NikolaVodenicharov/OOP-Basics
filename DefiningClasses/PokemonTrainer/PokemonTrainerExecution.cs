namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class PokemonTrainerExecution
    {
        static void Main()
        {
            var trainers = new List<Trainer>();

            // add trainers with pokemons;
            while (true)
            {
                var inputLine = Console.ReadLine();

                bool stopLoop = inputLine.Equals("Tournament", StringComparison.OrdinalIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                var splitInutLine = inputLine.Split();

                Pokemon pokemon = MakePokemon(splitInutLine);

                var trainerName = splitInutLine[0];
                AddTrainer(trainers, trainerName);
                trainers.Single(x => x.Name == trainerName).AddPokemon(pokemon);
            }

            // tournament
            while (true)
            {
                var inputLine = Console.ReadLine();

                bool stopLoop = inputLine.Equals("End", StringComparison.OrdinalIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                for (int i = 0; i < trainers.Count; i++)
                {
                    if (trainers[i].Pokemons.Any(x => x.Element == inputLine))
                    {
                        trainers[i].AddBadge();
                    }
                    else
                    {
                        trainers[i].LosePokemonsHealt();
                    }
                }
            }

            PrintTrainers(trainers);
        }

        private static void PrintTrainers(List<Trainer> trainers)
        {
            var sb = new StringBuilder();
            foreach (var trainer in trainers.OrderByDescending(x => x.BadgesNumber))
            {
                sb.AppendLine($"{trainer.Name} {trainer.BadgesNumber} {trainer.Pokemons.Count}");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void AddTrainer(List<Trainer> trainers, string trainerName)
        {
            if (!trainers.Any(x => x.Name == trainerName))
            {
                var trainer = new Trainer(trainerName);
                trainers.Add(trainer);
            }
        }

        private static Pokemon MakePokemon(string[] splitInutLine)
        {
            var name = splitInutLine[1];
            var element = splitInutLine[2];
            var healt = int.Parse(splitInutLine[3]);

            var pokemon = new Pokemon(name, element, healt);

            return pokemon;
        }
    }
}

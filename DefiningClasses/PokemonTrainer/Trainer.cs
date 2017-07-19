namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;

    public class Trainer
    {
        private const int HealtPointsLoss = 10;

        private string name;
        private int badgesNumber;
        private List<Pokemon> pokemons;

        public Trainer (string name)
        {
            this.Name = name;
            this.badgesNumber = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException($"{nameof(Name)} cannot be null or empty");
                }

                this.name = value;
            }
        }
        
        public int BadgesNumber
        {
            get
            {
                return this.badgesNumber;
            }
        }
        
        public List<Pokemon> Pokemons
        {
            get
            {
                return this.pokemons;
            }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public void AddBadge()
        {
            this.badgesNumber += 1;
        }

        public void LosePokemonsHealt()
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i].Health - HealtPointsLoss <= 0)
                {
                    pokemons.RemoveAt(i);
                    i--;
                    continue;
                }

                pokemons[i].LoseHealt(HealtPointsLoss);
            }
        }
    }
}

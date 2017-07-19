namespace PokemonTrainer
{
    using System;

    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon (string name, string element, int healt)
        {
            this.Name = name;
            this.Element = element;
            this.Health = healt;
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

        public string Element
        {
            get
            {
                return this.element;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException($"{nameof(Element)} cannot be null or empty");
                }

                this.element = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Health)} cannot be zero or negative");
                }

                this.health = value;
            }
        }

        public void LoseHealt (int loss)
        {
            this.health -= loss;
        }
    }
}

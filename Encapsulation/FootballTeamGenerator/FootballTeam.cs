namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FootballTeam
    {
        private string name;
        private List<Player> players;

        public FootballTeam(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                bool isInvalid = string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
                if (isInvalid)
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            bool validPlayer = this.players.Any(x => x.Name == playerName);
            if (!validPlayer)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
            }

            var item = this.players.Single(x => x.Name == playerName);
            this.players.Remove(item);
        }

        public double CalculateRating()
        {
            double rating = 0;
            if (this.players.Count > 0)
            {
                rating += this.players.Average(x => x.CalculateSkillLevel());
            }
            
            return rating;
        }
    }
}

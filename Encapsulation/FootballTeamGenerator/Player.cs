namespace FootballTeamGenerator
{
    using System;

    public class Player
    {
        private const double MinimumStats = 1;
        private const double MaximumStats = 100;

        private string name;

        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player (string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public double Endurance
        {
            get
            {
                return this.endurance;
            }

            set
            {
                if (value < MinimumStats || value > MaximumStats)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        public double Sprint
        {
            get
            {
                return this.sprint;
            }

            set
            {
                if (value < MinimumStats || value > MaximumStats)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        public double Dribble
        {
            get
            {
                return this.dribble;
            }

            set
            {
                if (value < MinimumStats || value > MaximumStats)
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        public double Passing
        {
            get
            {
                return this.passing;
            }

            set
            {
                if (value < MinimumStats || value > MaximumStats)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        public double Shooting
        {
            get
            {
                return this.shooting;
            }

            set
            {
                if (value < MinimumStats || value > MaximumStats)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        public double CalculateSkillLevel()
        {
            double skillLevel = (
                this.endurance + 
                this.sprint + 
                this.dribble + 
                this.passing + 
                this.shooting) 
                / 5;

            return skillLevel;
        }
    }
}

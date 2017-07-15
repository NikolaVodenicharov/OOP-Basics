namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FootballTeamGeneratorExecution
    {
        static void Main()
        {
            var teams = new List<FootballTeam>();

            while (true)
            {
                var inputLine = Console.ReadLine().Split(';');

                bool stopLoop = inputLine[0].Equals("end", StringComparison.OrdinalIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                try
                {
                    OperateInput(teams, inputLine);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void OperateInput(List<FootballTeam> teams, string[] inputLine)
        {
            if (inputLine[0].Equals("team", StringComparison.OrdinalIgnoreCase))
            {
                teams.Add(new FootballTeam(inputLine[1]));
            }
            else if (inputLine[0].Equals("add", StringComparison.OrdinalIgnoreCase))
            {
                CheckTeamExistence(teams, inputLine);

                Player player = CreatePlayer(inputLine);
                teams.Single(x => x.Name == inputLine[1]).AddPlayer(player);
            }
            else if (inputLine[0].Equals("remove", StringComparison.OrdinalIgnoreCase))
            {
                CheckTeamExistence(teams, inputLine);

                teams.Single(x => x.Name == inputLine[1]).RemovePlayer(inputLine[2]);
            }
            else if (inputLine[0].Equals("rating", StringComparison.OrdinalIgnoreCase))
            {
                CheckTeamExistence(teams, inputLine);

                double rating = teams.Single(x => x.Name == inputLine[1]).CalculateRating();
                double roundedRating = Math.Round(rating);
                Console.WriteLine($"{inputLine[1]} - {roundedRating}");
            }
        }

        private static Player CreatePlayer(string[] inputLine)
        {
            string name = inputLine[2];
            double endurance = double.Parse(inputLine[3]);
            double sprint = double.Parse(inputLine[4]);
            double dribble = double.Parse(inputLine[5]);
            double passing = double.Parse(inputLine[6]);
            double shooting = double.Parse(inputLine[7]);

            Player player = new Player(name, endurance, sprint, dribble, passing, shooting);

            return player;
        }

        private static void CheckTeamExistence(List<FootballTeam> teams, string[] inputLine)
        {
            bool existingTeam = teams.Any(x => x.Name == inputLine[1]);
            if (!existingTeam)
            {
                throw new ArgumentException($"Team {inputLine[1]} does not exist.");
            }
        }
    }
}

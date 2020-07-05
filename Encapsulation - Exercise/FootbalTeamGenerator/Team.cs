using System;
using System.Collections.Generic;

namespace FootbalTeamGenerator
{
    public class Team
    {
        private List<Player> team;
        private string name;

        public Team(string name)
        {
            this.team = new List<Player>();

            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get
            {
                double rating = 0;
                foreach (var player in this.team)
                {
                    rating += (player.Endurance + player.Sprint + player.Dribble + player.Passing + player.Shooting) / 5.0;
                }

                return Math.Round(rating);
            }
        }

        public void Add(Player player)
        {
            this.team.Add(player);
        }

        public void Remove(string playerName)
        {
            var player = this.team.Find(pl => pl.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.team.Remove(player);
        }
    }
}

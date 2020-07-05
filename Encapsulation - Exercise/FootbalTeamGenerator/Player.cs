using System;

namespace FootbalTeamGenerator
{
    public class Player
    {
        private const int MIN_STAT_VALUE = 0;
        private const int MAX_STAT_VALUE = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
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

        public int Endurance 
        { 
            get => this.endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.endurance = value;
            }
        }

        public int Sprint 
        { 
            get => this.sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Sprint should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.sprint = value;
            }
        }

        public int Dribble 
        { 
            get => this.dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribble should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.dribble = value;
            }
        }

        public int Passing 
        { 
            get => this.passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.passing = value;
            }
        }

        public int Shooting 
        {
            get => this.shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.shooting = value;
            }
        }
    }
}

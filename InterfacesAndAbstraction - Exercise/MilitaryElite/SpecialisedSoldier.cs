using System;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : 
            base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps 
        {
            get => this.corps;
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corps!");
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            
            return sb.ToString().Trim();
        }
    }
}

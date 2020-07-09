using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier
    {
        private IEnumerable<Mission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps, IEnumerable<Mission> missions) : 
            base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var mission in this.missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }
            
            return sb.ToString().Trim();
        }
    }
}
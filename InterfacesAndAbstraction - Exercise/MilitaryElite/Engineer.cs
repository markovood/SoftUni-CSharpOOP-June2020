using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier
    {
        private IEnumerable<Repair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps, IEnumerable<Repair> repairs) : 
            base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var repair in this.repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }
            
            return sb.ToString().Trim();
        }
    }
}
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private
    {
        private IEnumerable<Private> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, IEnumerable<Private> privates) :
            base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var soldier in this.privates)
            {
                sb.AppendLine("  " + soldier.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
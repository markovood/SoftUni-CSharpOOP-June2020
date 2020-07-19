using System.Collections.Generic;
using System.Text;

namespace Detail_Printer_After
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) :
            base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string Details()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);
            foreach (var doc in this.Documents)
            {
                sb.AppendLine("  " + doc);
            }

            return sb.ToString().Trim();
        }
    }
}
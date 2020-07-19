using Detail_Printer_After.Contracts;

namespace Detail_Printer_After
{
    public abstract class Employee : IDetailable
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract string Details();
    }
}
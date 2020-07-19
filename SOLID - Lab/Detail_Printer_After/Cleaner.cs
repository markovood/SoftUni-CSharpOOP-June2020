namespace Detail_Printer_After
{
    public class Cleaner : Employee
    {
        public Cleaner(string name) :
            base(name)
        {
        }

        public override string Details()
        {
            return this.Name;
        }
    }
}
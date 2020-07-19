namespace Detail_Printer_After
{
    public class Worker : Employee
    {
        public Worker(string name) :
            base(name)
        {
        }

        public override string Details()
        {
            return this.Name;
        }
    }
}
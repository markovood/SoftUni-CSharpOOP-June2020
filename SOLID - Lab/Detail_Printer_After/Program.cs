using System.Collections.Generic;

namespace Detail_Printer_After
{
    public class Program
    {
        public static void Main()
        {
            var worker = new Worker("Pesho");
            var manager = new Manager("Gosho", new List<string>() { "doc1", "doc2", "doc3" });
            var cleaner = new Cleaner("baba Neli");

            var printer = new DetailsPrinter(new List<Employee>() { worker, cleaner, manager });
            printer.PrintDetails();
        }
    }
}
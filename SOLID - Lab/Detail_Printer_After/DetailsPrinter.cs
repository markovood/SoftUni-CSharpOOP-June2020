using System;
using System.Collections.Generic;

namespace Detail_Printer_After
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (var employee in this.employees)
            {
                Console.WriteLine(employee.Details());
            }
        }
    }
}
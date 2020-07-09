using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> numbers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            List<string> urls = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            var stationaryPhone = new StationaryPhone("Dialing... ");
            var smartPhone = new SmartPhone("Calling... ");

            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.Call(number);
                }
                else if (number.Length == 10)
                {
                    smartPhone.Call(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var url in urls)
            {
                smartPhone.Browse(url);
            }
        }
    }
}
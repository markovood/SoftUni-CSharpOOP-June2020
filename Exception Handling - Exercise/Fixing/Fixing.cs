using System;

namespace Fixing
{
    public class Fixing
    {
        public static void Main()
        {
            string[] weekdays = new string[5];
            weekdays[0] = "Sunday";
            weekdays[1] = "Monday";
            weekdays[2] = "Tuesday";
            weekdays[3] = "Wednesday";
            weekdays[4] = "Thursday";

            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"index was {i}, but last possible is {weekdays.Length - 1}");
                }
            }

            Console.ReadLine();
        }
    }
}
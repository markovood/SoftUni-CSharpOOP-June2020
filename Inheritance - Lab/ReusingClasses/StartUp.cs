using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            var randList = new RandomList()
            {
                "Pesho",
                "Gosho",
                "Stamat",
                "Misho",
                "Todor"
            };

            Console.WriteLine(randList.RandomString());
        }
    }
}

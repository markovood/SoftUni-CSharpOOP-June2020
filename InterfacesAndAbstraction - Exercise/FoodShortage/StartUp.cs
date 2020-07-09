using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            List<IPerson> people = new List<IPerson>();
            for (int i = 0; i < N; i++)
            {
                string[] peopleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = peopleInfo[0];
                int age = int.Parse(peopleInfo[1]);
                if (peopleInfo.Length == 3)
                {
                    // rebel
                    string group = peopleInfo[2];
                    var rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }
                else
                {
                    // citizen
                    string id = peopleInfo[2];
                    string birthdate = peopleInfo[3];
                    var citizen = new Citizen(name, age, id, birthdate);
                    people.Add(citizen);
                }
            }

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                var person = people.FirstOrDefault(d => d.Name == name);
                if (person != null)
                {
                    (person as IBuyer).BuyFood();
                }
            }

            int totalFood = 0;
            foreach (var item in people)
            {
                totalFood += (item as IBuyer).Food;
            }

            Console.WriteLine(totalFood);
        }
    }
}
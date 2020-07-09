using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main()
        {
            List<IBirthable> birthables = new List<IBirthable>();
            while (true)
            {
                string[] unitInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (unitInfo[0] == "End")
                {
                    break;
                }

                switch (unitInfo[0])
                {
                    case "Citizen":
                        string name = unitInfo[1];
                        int age = int.Parse(unitInfo[2]);
                        string id = unitInfo[3];
                        string birthdate = unitInfo[4];

                        var citizen = new Citizen(name, age, id, birthdate);

                        birthables.Add(citizen);
                        break;
                    case "Robot":
                        string model = unitInfo[1];
                        id = unitInfo[2];

                        var robot = new Robot(model, id);
                        break;
                    case "Pet":
                        name = unitInfo[1];
                        birthdate = unitInfo[2];

                        var pet = new Pet(name, birthdate);
                        birthables.Add(pet);
                        break;
                }
            }

            string year = Console.ReadLine();
            birthables
                .Where(b => b.Birthdate.EndsWith(year))
                .ToList()
                .ForEach(b => Console.WriteLine(b.Birthdate));
        }
    }
}
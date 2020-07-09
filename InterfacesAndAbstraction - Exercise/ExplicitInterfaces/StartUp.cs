using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                string[] citizenInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (citizenInfo[0] == "End")
                {
                    break;
                }

                var citizen = new Citizen(citizenInfo[0], citizenInfo[1], int.Parse(citizenInfo[2]));
                Console.WriteLine(citizen.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
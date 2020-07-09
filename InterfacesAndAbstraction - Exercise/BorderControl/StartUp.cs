using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main()
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            while (true)
            {
                string[] identifiableInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (identifiableInfo[0] == "End")
                {
                    break;
                }

                switch (identifiableInfo.Length)
                {
                    case 2:
                        //robot
                        var robot = new Robot(identifiableInfo[0], identifiableInfo[1]);
                        identifiables.Add(robot);
                        break;
                    case 3:
                        //citizen
                        var citizen = new Citizen(identifiableInfo[0], int.Parse(identifiableInfo[1]), identifiableInfo[2]);
                        identifiables.Add(citizen);
                        break;
                }
            }

            string fakeIdEnd = Console.ReadLine();
            identifiables
                .FindAll(x => x.Id.EndsWith(fakeIdEnd))
                .ForEach(x => Console.WriteLine(x.Id));
        }
    }
}

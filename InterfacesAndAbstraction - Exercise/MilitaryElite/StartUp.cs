using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main()
        {
            List<Soldier> soldiers = new List<Soldier>();
            while (true)
            {
                string[] soldierInfo = Console.ReadLine().Split();
                if (soldierInfo[0] == "End")
                {
                    break;
                }

                int id = int.Parse(soldierInfo[1]);
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];
                switch (soldierInfo[0])
                {
                    case "Private":
                        decimal salary = decimal.Parse(soldierInfo[4]);
                        var @private = new Private(id, firstName, lastName, salary);
                        soldiers.Add(@private);
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(soldierInfo[4]);
                        var ids = soldierInfo.Skip(5).Select(int.Parse);
                        List<Private> privates = new List<Private>();
                        foreach (var privateId in ids)
                        {
                            var soldier = soldiers.FirstOrDefault(s => s.Id == privateId);
                            if (soldier != null)
                            {
                                privates.Add(soldier as Private);
                            }
                        }

                        var general = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                        soldiers.Add(general);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(soldierInfo[4]);
                        string corps = soldierInfo[5];
                        var repairs = new List<Repair>();
                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            string partName = soldierInfo[i];
                            int hoursWorked = int.Parse(soldierInfo[i + 1]);
                            var repair = new Repair(partName, hoursWorked);
                            repairs.Add(repair);
                        }

                        try
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                            soldiers.Add(engineer);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }

                        break;
                    case "Commando":
                        salary = decimal.Parse(soldierInfo[4]);
                        corps = soldierInfo[5];
                        var missions = new List<Mission>();
                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            string codeName = soldierInfo[i];
                            string state = soldierInfo[i + 1];
                            try
                            {
                                var mission = new Mission(codeName, state);
                                missions.Add(mission);
                            }
                            catch (ArgumentException)
                            {
                                continue;
                            }
                        }

                        try
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corps, missions);
                            soldiers.Add(commando);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }

                        break;
                    case "Spy":
                        int codeNumber = int.Parse(soldierInfo[4]);
                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(spy);
                        break;
                }
            }

            //soldiers.ForEach(Console.WriteLine);
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
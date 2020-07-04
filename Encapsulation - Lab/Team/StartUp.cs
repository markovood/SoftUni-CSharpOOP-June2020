using System;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            Team team = new Team("SoftUni");

            int numbOfpersons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbOfpersons; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person player = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            decimal.Parse(cmdArgs[3]));
                team.AddPlayer(player);
            }

            Console.WriteLine(team);
        }
    }
}
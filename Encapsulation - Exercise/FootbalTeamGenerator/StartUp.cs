using System;
using System.Collections.Generic;
using System.Linq;

namespace FootbalTeamGenerator
{
    public class StartUp
    {
        public static void Main()
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0] == "END")
                {
                    break;
                }

                string teamName = cmdArgs[1];
                switch (cmdArgs[0])
                {
                    case "Team":
                        // Team;Arsenal
                        try
                        {
                            teams.Add(new Team(teamName));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "Add":
                        // Add;Arsenal;Kieran_Gibbs;75;85;84;92;67
                        var team = teams.FirstOrDefault(t => t.Name == teamName);
                        try
                        {
                            if (team == null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            var player = new Player(cmdArgs[2],
                                                                    int.Parse(cmdArgs[3]),
                                                                    int.Parse(cmdArgs[4]),
                                                                    int.Parse(cmdArgs[5]),
                                                                    int.Parse(cmdArgs[6]),
                                                                    int.Parse(cmdArgs[7]));
                            team.Add(player);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "Remove":
                        // Remove;Arsenal;Aaron_Ramsey
                        try
                        {
                            team = teams.Find(t => t.Name == teamName);
                            team.Remove(cmdArgs[2]);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "Rating":
                        // Rating;Arsenal
                        try
                        {
                            team = teams.Find(t => t.Name == teamName);
                            if (team == null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            Console.WriteLine($"{team.Name} - {team.Rating}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                }
            }
        }
    }
}

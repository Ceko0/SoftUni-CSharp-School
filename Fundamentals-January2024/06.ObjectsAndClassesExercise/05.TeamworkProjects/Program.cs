using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.TeamworkProjects
{
    class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            TeamMembers = new List<string>();
        }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> TeamMembers { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name}");
            sb.AppendLine($"- {Creator}");
            foreach (var member in TeamMembers.OrderBy(member => member))
            {
                sb.AppendLine($"-- {member}");
            }
            return sb.ToString().TrimEnd();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int teamCapacity = int.Parse(Console.ReadLine());
            List<Team> teamList = new List<Team>();

            for (int i = 0; i < teamCapacity; i++)
            {
                string[] teamToCreate = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string teamName = teamToCreate[1];
                string creator = teamToCreate[0];

                if (teamList.Any(t => t.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else if (teamList.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else
                {
                    teamList.Add(new Team(teamName, creator));
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] peopleToJoin = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string member = peopleToJoin[0];
                string teamName = peopleToJoin[1];

                Team team = teamList.FirstOrDefault(t => t.Name == teamName);

                bool existinMember = false;
                foreach (Team teams in teamList)
                {
                    foreach (var members in teams.TeamMembers)
                    {
                        if (members == member)
                        {
                            existinMember = true;
                            break;
                        }
                    }
                }
                
                if (team == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (existinMember || team.Creator == member)
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else
                {
                    team.TeamMembers.Add(member);
                }
            }

            List<Team> teamToPrint = teamList
                .Where(t => t.TeamMembers.Count > 0)
                .OrderBy(t => t.Name)
                .ToList();

            List<Team> teamToDisband = teamList
                .Where(t => t.TeamMembers.Count == 0)
                .ToList();

            teamList.RemoveAll(t => t.TeamMembers.Count == 0);

            foreach (Team team in teamToPrint.OrderByDescending(t => t.TeamMembers.Count))
            {
                Console.WriteLine(team);
            }
            Console.WriteLine("Teams to disband:");


            foreach (Team team in teamToDisband.OrderBy(t => t.Name))
            {
                Console.WriteLine(team.Name);
            }

        }
    }
}

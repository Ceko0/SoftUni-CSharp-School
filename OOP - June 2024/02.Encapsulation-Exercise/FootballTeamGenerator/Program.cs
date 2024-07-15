namespace FootballTeamGenerator;
public class Program
{
    static void Main()
    {
        Dictionary<string, Team> teams = new();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] info = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

            string action = info[0];
            string teamName = info[1];

            try
            {
                switch (action)
                {
                    case "Team":
                        teams[teamName] = new Team(teamName);
                        break;
                    case "Add":
                        Team team = TeamCheck(teams, teamName);
                        Player player = new(info[2], int.Parse(info[3]), int.Parse(info[4]), int.Parse(info[5]), int.Parse(info[6]), int.Parse(info[7]));
                        team.AddPlayer(player);
                        break;
                    case "Remove":
                        team = TeamCheck(teams, teamName);
                        if (!teams[teamName].RemovePlayer(info[2])) Console.WriteLine($"Player {info[2]} is not in {teamName} team."); 
                        break;
                    case "Rating":
                        team = TeamCheck(teams, teamName);
                        Console.WriteLine($"{teamName} - { teams[teamName].Rating}") ;
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

    private static Team TeamCheck(Dictionary<string, Team> teams, string teamName)
    {
        if (!teams.TryGetValue(teamName, out var team)) Console.WriteLine($"Team {teamName} does not exist.");
        return team;
    }
}


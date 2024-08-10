using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Models.PlayerChild;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System.Linq;
using System.Text;

namespace Handball.Core
{
    public class Controller : IController
    {
        private readonly PlayerRepository players = new();
        private readonly TeamRepository teams = new();
        public string NewTeam(string name)
        {
            ITeam teamToCheck = teams.Models.FirstOrDefault(x => x.Name == name);
            if (teamToCheck != null) return string.Format(OutputMessages.TeamAlreadyExists, name, typeof(TeamRepository).Name);
            ITeam team = new Team(name);
            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, typeof(TeamRepository).Name);
        }
        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = typeName == typeof(Goalkeeper).Name
                ? new Goalkeeper(name)
                : typeName == typeof(CenterBack).Name
                    ? new CenterBack(name)
                    : typeName == typeof(ForwardWing).Name
                        ? new ForwardWing(name)
                        : null;

            if (player == null)
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);

            IPlayer playerToCheck = players.Models.FirstOrDefault(x => x.Name == name);

            if (playerToCheck != null)
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, typeof(PlayerRepository).Name, playerToCheck.GetType().Name);

            players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }
        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = players.Models.FirstOrDefault(x => x.Name == playerName);
            if (player == null)
                return string.Format(OutputMessages.PlayerNotExisting, playerName, typeof(PlayerRepository).Name);
            ITeam team = teams.Models.FirstOrDefault(x => x.Name == teamName);
            if (team == null)
                return string.Format(OutputMessages.TeamNotExisting, teamName, typeof(TeamRepository).Name);
            if (player.Team != null)
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            player.JoinTeam(teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }
        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firsTeam = teams.Models.FirstOrDefault(x => x.Name == firstTeamName);
            ITeam secondTeam = teams.Models.FirstOrDefault(y => y.Name == secondTeamName);
            if (firsTeam.OverallRating > secondTeam.OverallRating)
            {
                firsTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else if (secondTeam.OverallRating > firsTeam.OverallRating)
            {
                secondTeam.Win();
                firsTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }
            firsTeam.Draw();
            secondTeam.Draw();
            return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
        }
        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new();
            ITeam team = teams.Models.FirstOrDefault(x => x.Name == teamName);
            sb.AppendLine($"***{teamName}***");
            foreach (IPlayer player in team.Players
                         .OrderByDescending(x => x.Rating)
                         .ThenBy(x => x.Name)) 
                sb.AppendLine(player.ToString());
            
            return sb.ToString().TrimEnd();
        }
        public string LeagueStandings()
        {
            StringBuilder sb = new();
            foreach (ITeam team in teams.Models
                         .OrderByDescending(x => x.PointsEarned)
                         .ThenByDescending(x => x.OverallRating)
                         .ThenBy(x => x.Name))
                sb.AppendLine(team.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}

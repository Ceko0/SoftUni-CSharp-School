using System.Text;
using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Models.ManagerChild;
using FootballManager.Repositories;
using FootballManager.Utilities.Messages;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        private TeamRepository teams = new() ;
        public string JoinChampionship(string teamName)
        {
            ITeam team = new Team(teamName);
            if (teams.Models.Count == teams.Capacity) return OutputMessages.ChampionshipFull;
            if (teams.Models.Any(x => x.Name == teamName)) return string.Format(OutputMessages.TeamWithSameNameExisting, teamName);

            teams.Add(team);

            return string.Format(OutputMessages.TeamSuccessfullyJoined, teamName);
        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            ITeam team = teams.Models.FirstOrDefault(x => x.Name == teamName);
            IManager? manager = managerTypeName == typeof(AmateurManager).Name
                ? new AmateurManager(managerName)
                : managerTypeName == typeof(ProfessionalManager).Name
                    ? new ProfessionalManager(managerName)
                    : managerTypeName == typeof(SeniorManager).Name
                        ? new SeniorManager(managerName)
                        : null;
            if (team == null)
                return string.Format(OutputMessages.TeamDoesNotTakePart, teamName);

            if (manager == null)
                return string.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);

            if (team.TeamManager != null)
                return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);

            foreach (ITeam currentTeam in teams.Models)
            {
                if (currentTeam.TeamManager != null)
                {
                    if (currentTeam.TeamManager.Name == managerName)
                        return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
                }
            }

            team.SignWith(manager);
            return string.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);

        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            ITeam teamOne = teams.Models.FirstOrDefault(x => x.Name == teamOneName);
            ITeam teamTwo = teams.Models.FirstOrDefault(x => x.Name == teamTwoName);
            if (teamOne == null || teamTwo == null) return OutputMessages.OneOfTheTeamDoesNotExist;
            if (teamOne.PresentCondition > teamTwo.PresentCondition)
            {
                teamOne.GainPoints(3);
                if (teamOne.TeamManager != null) teamOne.TeamManager.RankingUpdate(5);
                if (teamTwo.TeamManager != null) teamTwo.TeamManager.RankingUpdate(-5);
                return string.Format(OutputMessages.TeamWinsMatch, teamOneName, teamTwoName);
            }
            else if (teamOne.PresentCondition < teamTwo.PresentCondition)
            {
                teamTwo.GainPoints(3);
                if (teamTwo.TeamManager != null) teamTwo.TeamManager.RankingUpdate(5);
                if (teamOne.TeamManager != null) teamOne.TeamManager.RankingUpdate(-5);
                return string.Format(OutputMessages.TeamWinsMatch, teamTwoName, teamOneName);
            }

            teamOne.GainPoints(1);
            teamTwo.GainPoints(1);
            return string.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);
        }

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            ITeam droppingTeam = teams.Models.FirstOrDefault(x => x.Name == droppingTeamName);
            if (droppingTeam == null) return string.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);

            ITeam promotingTeam = teams.Models.FirstOrDefault(x => x.Name == promotingTeamName);
            if (promotingTeam != null) return string.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);

            promotingTeam = new Team(promotingTeamName);

            bool managerIsUsed = false;
            foreach (ITeam currentTeam in teams.Models)
            {
                if (currentTeam.TeamManager.Name == managerName)
                {
                    managerIsUsed = true;
                    break;
                }
            }
            IManager? manager = managerTypeName == typeof(AmateurManager).Name
                ? new AmateurManager(managerName)
                : managerTypeName == typeof(ProfessionalManager).Name
                    ? new ProfessionalManager(managerName)
                    : managerTypeName == typeof(SeniorManager).Name
                        ? new SeniorManager(managerName)
                        : null;
            if(manager != null) promotingTeam.SignWith(manager);

            foreach (ITeam currentTeam in teams.Models)
            {
                currentTeam.ResetPoints();
            }

            teams.Remove(droppingTeamName);
            teams.Add(promotingTeam);

            return string.Format(OutputMessages.TeamHasBeenPromoted,promotingTeamName);
        }

        public string ChampionshipRankings()
        {
            StringBuilder sb = new();
            sb.AppendLine("***Ranking Table***");
            int positionCounter = 1;
            foreach (ITeam team in teams.Models
                         .OrderByDescending( x => x.ChampionshipPoints)
                         .ThenByDescending(x => x.PresentCondition))
            {
                sb.AppendLine($"{positionCounter++}. {team.ToString()}/{team.TeamManager.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

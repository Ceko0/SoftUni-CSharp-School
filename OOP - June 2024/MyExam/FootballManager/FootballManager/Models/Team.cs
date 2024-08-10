using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    public class Team : ITeam
    {
        public Team(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.TeamNameNull);
            Name = name;
            ChampionshipPoints = 0;
        }

        public string Name { get; }
        public int ChampionshipPoints { get; private set; }
        public IManager TeamManager { get; private set; }

        public int PresentCondition
        {
            get
            {
                if (TeamManager == null)
                {
                    return 0;
                }

                if (ChampionshipPoints == 0)
                {
                    
                    return (int)Math.Floor(TeamManager.Ranking);
                }

                double condition = ChampionshipPoints * TeamManager.Ranking;

                return (int)Math.Floor(condition);
            }
        }

        public void SignWith(IManager manager)
        {
            if (manager != null) TeamManager = manager;
        }

        public void GainPoints(int points) => ChampionshipPoints += points;
        

        public void ResetPoints() => ChampionshipPoints = 0;

        public override string ToString() => $"Team: {Name} Points: {ChampionshipPoints}";
    }
}

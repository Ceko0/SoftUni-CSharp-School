namespace FootballManager.Models.ManagerChild
{
    public class ProfessionalManager : Manager
    {
        private const double PMStartingRanking = 60;
        public ProfessionalManager(string name) 
            : base(name, PMStartingRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            Ranking += updateValue * 1.5;
            if (Ranking < MinRanking) Ranking = MinRanking;
            if (Ranking > MaxRanking) Ranking = MaxRanking;
        }
    }
}

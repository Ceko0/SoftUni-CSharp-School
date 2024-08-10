namespace FootballManager.Models.ManagerChild
{
    public class SeniorManager :Manager
    {
        private const double SMStartingRanking = 30;
        public SeniorManager(string name) 
            : base(name, SMStartingRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            Ranking += updateValue;
            if (Ranking < MinRanking) Ranking = MinRanking;
            if (Ranking > MaxRanking) Ranking = MaxRanking;
        }
    }
}

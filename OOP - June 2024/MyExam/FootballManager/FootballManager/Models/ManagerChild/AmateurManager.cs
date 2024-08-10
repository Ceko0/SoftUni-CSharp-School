namespace FootballManager.Models.ManagerChild
{
    public class AmateurManager : Manager
    {
        private const double AMStartingRanking = 15;

        public AmateurManager(string name)
            : base(name, AMStartingRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            Ranking += updateValue * 0.75;
            if (Ranking < MinRanking) Ranking = MinRanking;
            if (Ranking > MaxRanking) Ranking = MaxRanking;
        }
    }
}

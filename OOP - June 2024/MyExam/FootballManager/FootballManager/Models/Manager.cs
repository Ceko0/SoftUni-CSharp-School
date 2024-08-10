using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    public abstract class Manager :IManager
    {
        protected const double MinRanking = 0.0;
        protected const double MaxRanking = 100.0;
        protected Manager(string name, double ranking)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.ManagerNameNull);

            Name = name;
            Ranking = ranking;
        }

        public string Name { get; }
        public double Ranking { get; protected set; }
        public abstract void RankingUpdate(double updateValue);
        public override string ToString() => $"{Name} - {GetType().Name} (Ranking: {Ranking:F2})";
    }
}

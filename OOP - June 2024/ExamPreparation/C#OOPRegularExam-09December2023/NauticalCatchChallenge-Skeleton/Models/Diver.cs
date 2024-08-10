using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private readonly List<string> _catch;
        protected Diver(string name, int oxygenLevel)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.DiversNameNull);
            Name = name;
            OxygenLevel = oxygenLevel;
            _catch = new();
            CompetitionPoints = 0.0;
            HasHealthIssues = false;
        }

        public string Name { get; }
        public int OxygenLevel { get; protected set; }
        public IReadOnlyCollection<string> Catch => _catch.AsReadOnly();
        public double CompetitionPoints { get; private set; }
        public bool HasHealthIssues { get; private set; }
        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            _catch.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }
        public abstract void Miss(int TimeToCatch);
        public void UpdateHealthStatus()
        {
            if(HasHealthIssues) HasHealthIssues=false;
            else HasHealthIssues = true;
            if (OxygenLevel < 0) OxygenLevel = 0;
        }
        public abstract void RenewOxy();

        public override string ToString()
        {
            return
                $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}

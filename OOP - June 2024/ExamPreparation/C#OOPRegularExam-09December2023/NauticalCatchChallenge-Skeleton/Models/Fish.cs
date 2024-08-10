using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish :IFish
    {
        private const double MinPoints = 1;
        private const double MaxPoints = 10;
        protected Fish(string name, double points, int timeToCatch)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.FishNameNull);

            if (points < MinPoints || points > MaxPoints)
                throw new ArgumentException(ExceptionMessages.PointsNotInRange);
            if (timeToCatch < 0) TimeToCatch = 0;
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }

        public string Name { get; }
        public double Points { get; }
        public int TimeToCatch { get; }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}

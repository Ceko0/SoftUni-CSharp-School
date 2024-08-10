namespace Handball.Models.PlayerChild
{
    public class ForwardWing : Player
    {
        private const double GKRating = 5.5;
        private const int MinRating = 1;
        private const int MaxRating = 10;
        private const double ratingIncrease = 1.25;
        private const double ratingDecrease = 0.75;
        public ForwardWing(string name)
            : base(name, GKRating)
        {
        }

        public override void IncreaseRating()
        {
            Rating += ratingIncrease;
            if (Rating > MaxRating) Rating = MaxRating;
        }

        public override void DecreaseRating()
        {
            Rating -= ratingDecrease;
            if (Rating < MinRating) Rating = MinRating;
        }
    }
}

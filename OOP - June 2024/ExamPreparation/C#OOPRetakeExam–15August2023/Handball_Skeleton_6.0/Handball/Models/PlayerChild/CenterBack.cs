namespace Handball.Models.PlayerChild
{
    public class CenterBack : Player
    {
        private const double GKRating = 4;
        private const int MinRating = 1;
        private const int MaxRating = 10;
        private const double ratingIncrease = 1;
        private const double ratingDecrease = 1;
        public CenterBack(string name)
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

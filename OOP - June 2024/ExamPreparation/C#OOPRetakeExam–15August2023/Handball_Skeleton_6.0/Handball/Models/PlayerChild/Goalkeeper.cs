namespace Handball.Models.PlayerChild
{
    public class Goalkeeper : Player
    {
        private const double GKRating = 2.5;
        private const int MinRating = 1;
        private const int MaxRating = 10;
        private const double ratingIncrease = 0.75;
        private const double ratingDecrease = 1.25;
        public Goalkeeper(string name) 
            : base(name, GKRating)
        {
        }

        public override void IncreaseRating()
        {
            Rating += ratingIncrease;
            if ( Rating > MaxRating) Rating = MaxRating; 
        }

        public override void DecreaseRating()
        {
            Rating -= ratingDecrease;
            if(Rating < MinRating ) Rating = MinRating;
        }
    }
}

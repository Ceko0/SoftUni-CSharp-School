namespace NauticalCatchChallenge.Models.FishChild
{
    public class ReefFish :Fish
    {
        private const int RFTimeToCatch = 30;
        public ReefFish(string name, double points) 
            : base(name, points, RFTimeToCatch)
        {
        }
    }
}

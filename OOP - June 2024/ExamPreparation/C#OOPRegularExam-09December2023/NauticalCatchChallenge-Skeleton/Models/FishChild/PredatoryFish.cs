namespace NauticalCatchChallenge.Models.FishChild
{
    public class PredatoryFish :Fish
    {
        private const int PFTimeToCatch = 60;
        public PredatoryFish(string name, double points) 
            : base(name, points, PFTimeToCatch)
        {
        }
    }
}

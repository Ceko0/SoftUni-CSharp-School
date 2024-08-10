namespace NauticalCatchChallenge.Models.FishChild
{

    public class DeepSeaFish :Fish
    {
        private const int DFTimeToCatch = 180;

        public DeepSeaFish(string name, double points) 
            : base(name, points, DFTimeToCatch)
        {
        }
    }
}

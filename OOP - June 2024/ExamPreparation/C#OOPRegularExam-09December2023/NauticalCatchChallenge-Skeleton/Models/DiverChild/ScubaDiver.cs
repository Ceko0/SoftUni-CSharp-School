namespace NauticalCatchChallenge.Models.DiverChild
{
    public class ScubaDiver : Diver
    {
        private const int SDOxyden = 540;
        private const double decreaseOxygenPercent = 0.30;
        public ScubaDiver(string name) : base(name, SDOxyden)
        {
        }
        public override void Miss(int TimeToCatch) => OxygenLevel -= (int)(Math.Round((TimeToCatch * decreaseOxygenPercent), MidpointRounding.AwayFromZero));
        public override void RenewOxy() => OxygenLevel = SDOxyden;
    }
}

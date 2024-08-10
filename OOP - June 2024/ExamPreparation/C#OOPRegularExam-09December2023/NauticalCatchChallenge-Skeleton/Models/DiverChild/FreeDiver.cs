namespace NauticalCatchChallenge.Models.DiverChild
{
    public class FreeDiver : Diver
    {
        private const int FDOxyden = 120;
        private const double decreaseOxygenPercent = 0.60;
        public FreeDiver(string name) : base(name, FDOxyden)
        {
        }
        public override void Miss(int TimeToCatch) => OxygenLevel -= (int)(Math.Round((TimeToCatch* decreaseOxygenPercent), MidpointRounding.AwayFromZero));
        public override void RenewOxy() =>  OxygenLevel = FDOxyden;
    }
}

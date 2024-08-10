namespace HighwayToPeak.Models.ClimberChild
{
    public class OxygenClimber : Climber
    {
        private const int OCStamina = 10;
        public OxygenClimber(string name) : base(name, OCStamina)
        {
        }

        public override void Rest(int daysCount)
        {
            this.Stamina += daysCount;
            if (Stamina > 10 ) Stamina = 10;
        }
    }
}
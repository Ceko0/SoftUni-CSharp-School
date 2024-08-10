namespace HighwayToPeak.Models.ClimberChild
{
    public class NaturalClimber : Climber
    {
        private const int NCStamina = 6;
        public NaturalClimber(string name) : base(name, NCStamina)
        {
        }

        public override void Rest(int daysCount)
        {
            this.Stamina += daysCount * 2;
            if (Stamina > 10) Stamina = 10;
        }
    }
}
namespace Raiding.Models
{
    public class Rogue :BaseHero
    {
        const int DefaultPower = 80;
        public Rogue(string name)
            : base(name, DefaultPower)
        {
        }
        public override string action => $"hit for {Power} damage";
    }
}

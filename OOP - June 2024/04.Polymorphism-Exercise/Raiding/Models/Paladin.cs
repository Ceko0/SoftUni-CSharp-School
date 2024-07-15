namespace Raiding.Models
{
    internal class Paladin :BaseHero
    {
        const int DefaultPower = 100;
        public Paladin(string name)
            : base(name, DefaultPower)
        {
        }
        public override string action => $"healed for {Power}";
    }
}

namespace Raiding.Models
{
    public class Warrior :BaseHero
    {
        const int DefaultPower = 100;
        public Warrior(string name)
            : base(name, DefaultPower)
        {
        }
        public override string action => $"hit for {Power} damage";
    }
}

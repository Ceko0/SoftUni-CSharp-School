namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        const int DefaultPower = 80;
        public Druid(string name ) 
            : base(name, DefaultPower)
        {
            
        }
        public override string action => $"healed for {Power}"; 
    }
}

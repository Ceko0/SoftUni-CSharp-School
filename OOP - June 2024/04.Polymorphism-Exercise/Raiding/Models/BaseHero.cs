using Raiding.Interfaces;

namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; }

        public int Power { get; }

        public virtual string  action { get; }

        public string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} {action}";
        }
    }
}

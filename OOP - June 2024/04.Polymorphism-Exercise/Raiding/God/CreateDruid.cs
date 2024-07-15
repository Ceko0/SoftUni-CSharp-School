using Raiding.Interfaces;
using Raiding.Models;

namespace Raiding.God
{
    public class CreateDruid :IHeroCreator
    {
        public IHero Create(string name) => new Druid(name);

    }
}

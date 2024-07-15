using Raiding.Interfaces;
using Raiding.Models;

namespace Raiding.God
{
    public class CreatePaladin :IHeroCreator
    {
        public IHero Create(string name) => new Paladin(name);

    }
}

using Raiding.Interfaces;
using Raiding.Models;

namespace Raiding.God
{
    public class CreateRogue :IHeroCreator
    {
        public IHero Create(string name) => new Rogue(name);

    }
}

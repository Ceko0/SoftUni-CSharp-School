using Raiding.Interfaces;
using Raiding.Models;

namespace Raiding.God
{
    public class CreateWarrior :IHeroCreator
    {
        public IHero Create(string name) => new Warrior(name);

    }
}

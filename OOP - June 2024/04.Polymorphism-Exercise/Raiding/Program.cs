using Raiding.Interfaces;
using Raiding.Models;
using Raiding.God;

namespace Raiding
{
    public class Program
    {
        static void Main()
        {
             Dictionary<string, IHeroCreator> creator = new() { ["Druid"] = new CreateDruid() 
            , ["Paladin"] = new CreatePaladin(), ["Rogue"] = new CreateRogue(), ["Warrior"] = new CreateWarrior() };

            List<IHero> heroes = new();
            int heroesCount = int.Parse(Console.ReadLine());
            while (heroes.Count < heroesCount)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (creator.TryGetValue(type, out IHeroCreator? created)) heroes.Add(creator[type].Create(name));
                else Console.WriteLine("Invalid hero!");
            }
            int bossPower = int.Parse(Console.ReadLine());
            int raidPower = 0;
            foreach (IHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                raidPower += hero.Power;
            }
            if (raidPower >= bossPower) Console.WriteLine("Victory!");
            else Console.WriteLine("Defeat...");
        }
    }
}

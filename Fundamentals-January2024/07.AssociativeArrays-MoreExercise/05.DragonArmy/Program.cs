using System.Linq;

namespace _05.DragonArmy
{
    class Dragon
    {
        public Dragon(string name, int damage, int health, int armor)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragonsList = new Dictionary<string, List<Dragon>>();
            int dragonsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < dragonsCount; i++)
            {
                string[] dragonInformation = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = dragonInformation[0];
                string name = dragonInformation[1];
                int damage = 45;
                int health = 250;
                int armor = 10;
                if (dragonInformation[2] != "null")
                {
                    damage = int.Parse(dragonInformation[2]);
                }

                if (dragonInformation[3] != "null")
                {
                    health = int.Parse(dragonInformation[3]);
                }

                if (dragonInformation[4] != "null")
                {
                    armor = int.Parse(dragonInformation[4]);
                }

                Dragon currentDragon = new Dragon(name, damage, health, armor);
                if (!dragonsList.ContainsKey(type))
                {
                    dragonsList.Add(type, new List<Dragon>());
                    dragonsList[type].Add(currentDragon);
                }

                Dragon existingDragon = dragonsList[type].FirstOrDefault(d => d.Name == name);
                if (existingDragon != null)
                {
                    existingDragon.Armor = currentDragon.Armor;
                    existingDragon.Damage = currentDragon.Damage;
                    existingDragon.Health = currentDragon.Health;
                }
                else
                {
                    dragonsList[type].Add(currentDragon);
                }

            }

            foreach (var (type , dragonInfo) in dragonsList)
            {
                
                Console.WriteLine($"{type}::({(double)dragonInfo.Average(x => x.Damage):f2}/{(double)dragonInfo.Average(x => x.Health):f2}/{(double)dragonInfo.Average(x => x.Armor):f2})");
                foreach (var dragon in dragonInfo.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }
}

using System.Text;

namespace _03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        class Heroes
        {
            public Heroes(string name, int hp, int mp)
            {
                Name = name;
                HP = hp;
                MP = mp;
            }

            public string Name { get; set; }
            public int HP { get; set; }
            public int MP { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"{Name}");
                sb.AppendLine($"  HP: {HP}");
                sb.AppendLine($"  MP: {MP}");

                return sb.ToString();
            }
        }
        static void Main(string[] args)
        {
            int heroesCounter = int.Parse(Console.ReadLine());
            List<Heroes> allHeroes = new List<Heroes>();

            for (int i = 0; i < heroesCounter; i++)
            {
                string[] heroesInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = heroesInfo[0];
                int hitPoints = int.Parse(heroesInfo[1]);
                int manaPoints = int.Parse(heroesInfo[2]);
                Heroes heroes = new Heroes(name, hitPoints, manaPoints);
                allHeroes.Add(heroes);
            }
            string income = String.Empty;
            while ((income = Console.ReadLine()) != "End")
            {
                string[] commands = income
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = commands[0];
                string name = commands[1];
                Heroes currentHero = allHeroes.FirstOrDefault(x => x.Name == name);
                if (currentHero != null)
                {
                    switch (action)
                    {
                        case "CastSpell":
                            int manaNeeded = int.Parse(commands[2]);
                            string spellName = commands[3];
                            if (currentHero.MP >= manaNeeded)
                            {
                                currentHero.MP -= manaNeeded;
                                Console.WriteLine($"{name} has successfully cast {spellName} and now has {currentHero.MP} MP!");
                            }
                            else Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                            break;
                        case "TakeDamage":
                            int damage = int.Parse(commands[2]);
                            string attacker = commands[3];
                            currentHero.HP -= damage;
                            if (currentHero.HP > 0)
                            {
                                Console.WriteLine($"{currentHero.Name} was hit for {damage} HP by {attacker} and now has {currentHero.HP} HP left!");
                            }
                            else
                            {
                                Console.WriteLine($"{currentHero.Name} has been killed by {attacker}!");
                                allHeroes.Remove(currentHero);
                            }

                            break;
                        case "Recharge":
                            int amount = int.Parse(commands[2]);
                            if (currentHero.MP + amount > 200)
                            {
                                Console.WriteLine($"{name} recharged for {200 - currentHero.MP} MP!");
                                currentHero.MP = 200;
                            }
                            else
                            {
                                Console.WriteLine($"{name} recharged for {amount} MP!");
                                currentHero.MP += amount;
                            }

                            break;
                        case "Heal":
                            amount = int.Parse(commands[2]);
                            if (currentHero.HP + amount > 100)
                            {
                                Console.WriteLine($"{name} healed for {100 - currentHero.HP} HP!");
                                currentHero.HP = 100;
                            }
                            else
                            {
                                Console.WriteLine($"{name} healed for {amount} HP!");
                                currentHero.HP += amount;
                            }
                            break;

                    }
                }
            }
            Console.WriteLine(string.Join("", allHeroes));
        }
    }
}
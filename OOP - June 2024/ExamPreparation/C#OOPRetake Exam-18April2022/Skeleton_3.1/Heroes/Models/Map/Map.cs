using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Utilities.Messages;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        private readonly List<IHero> barbarians = new List<IHero>();
        private readonly List<IHero> knights = new List<IHero>();
        private int deadBarbarian = 0;
        private int deadKnight = 0;
        public string Fight(ICollection<IHero> players)
        {
            foreach (IHero hero in players)
            {
                if (hero.GetType().Name == typeof(Barbarian).Name) barbarians.Add(hero);
                else if (hero.GetType().Name == typeof(Knight).Name) knights.Add(hero);
            }

            while (deadBarbarian < barbarians.Count && deadKnight < knights.Count)
            {
                for (int i = 0; i < knights.Count; i++)
                {
                    IHero knight = knights[i];
                    int j = i;
                    if (j >= barbarians.Count && barbarians.Count != 0) j = barbarians.Count - 1;
                    IHero barbarian = barbarians[j];
                    if (knight.IsAlive)
                    {
                        if (knight.Weapon == null) continue;
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                        if (!barbarian.IsAlive) deadBarbarian++;
                    }
                }

                for (int i = 0; i < barbarians.Count; i++)
                {
                    IHero barbarian = barbarians[i];
                    int j = i;
                    if (j >= knights.Count && knights.Count != 0) j = knights.Count - 1;
                    IHero knight = knights[j];
                    if (barbarian.IsAlive)
                    {
                        if (barbarian.Weapon == null) continue;
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                        if (!knight.IsAlive) deadKnight++;
                    }
                }
            }

            if (knights.Count == deadKnight) return string.Format(OutputMessages.MapFigthBarbariansWin, deadBarbarian);

            return string.Format(OutputMessages.MapFightKnightsWin, deadKnight);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Utilities.Messages;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes = new HeroRepository();
        private readonly WeaponRepository weapons = new WeaponRepository();
        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weaponExist = weapons.Models.FirstOrDefault(x => x.Name == name);
            if (weaponExist != null)
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            IWeapon weapon;
            if (type == typeof(Mace).Name)
            {
                weapon = new Mace(name, durability);
                weapons.Add(weapon);
                return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
            }
            else if (type == typeof(Claymore).Name)
            {
                weapon = new Claymore(name, durability);
                weapons.Add(weapon);
                return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
            }

            throw new InvalidOperationException(string.Format(OutputMessages.WeaponTypeIsInvalid));
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero heroExist = heroes.Models.FirstOrDefault(x => x.Name == name);
            if (heroExist != null) throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist, name));

            IHero hero;
            if (type == typeof(Barbarian).Name)
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }
            else if (type == typeof(Knight).Name)
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return string.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }

            throw new InvalidOperationException(string.Format(OutputMessages.HeroTypeIsInvalid));
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.Models.FirstOrDefault(x => x.Name == heroName);
            if (hero == null)
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist, heroName));
            IWeapon weapon = weapons.Models.FirstOrDefault(x => x.Name == weaponName);
            if (weapon == null)
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            if (hero.Weapon != null)
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));

            hero.AddWeapon(weapon);
            string weaponType = weapon.GetType().Name.ToString();
            return string.Format(OutputMessages.WeaponAddedToHero, heroName,weaponType.ToLower());
        }

        public string StartBattle()
        {
            IMap map = new Map();
            List<IHero> heroesToFight = heroes.Models.ToList();
            return map.Fight(heroesToFight);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IHero hero in heroes.Models.OrderBy(x => x.GetType() == typeof(Knight)).ThenByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: { hero.Health }");
                sb.AppendLine($"--Armour: { hero.Armour }");
                if (hero.Weapon == null) sb.AppendLine($"--Weapon: Unarmed");
                else sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

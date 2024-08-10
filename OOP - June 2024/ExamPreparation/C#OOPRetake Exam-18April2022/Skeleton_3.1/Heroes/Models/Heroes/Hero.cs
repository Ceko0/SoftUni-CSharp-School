using Heroes.Models.Contracts;
using System;
using Heroes.Utilities.Messages;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        protected Hero(string name, int health, int armour)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.HeroNameNull);
            if (health < 0) throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
            if (armour < 0) throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);

            Name = name;
            Health = health;
            Armour = armour;
            IsAlive = true;
        }
        public string Name { get; }
        public int Health { get; private set; }
        public int Armour { get; private set; }
        public IWeapon Weapon { get; private set; }
        public bool IsAlive { get; private set; }
        public void TakeDamage(int points) 
        {
            if (points > Armour)
            {
                points -= Armour; 
                Armour = 0;
                if (points > Health)
                {
                    Health = 0;
                    IsAlive = false;
                }
                else Health -= points;
            }
            else Armour -= points;
        }
        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null) throw new ArgumentException(ExceptionMessages.WeaponNull);
            Weapon = weapon;
        }
        public int CompareTo(IHero other)
        {
            if (other == null) return 1;
            return this.Name.CompareTo(other.Name);
        }
        public int CompareTo(Hero other)
        {
            if (other == null) return 1;
            return this.Name.CompareTo(other.Name);
        }
    }
}

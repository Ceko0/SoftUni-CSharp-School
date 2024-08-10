using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        protected Weapon(string name, int durability)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.WeaponTypeNull);
            if (durability < 0) throw new ArgumentException(ExceptionMessages.DurabilityBelowZero);

            Name = name;
            Durability = durability;
        }
        public string Name { get; }
        public int Durability { get; protected set; }
        public abstract int DoDamage();
    }
}

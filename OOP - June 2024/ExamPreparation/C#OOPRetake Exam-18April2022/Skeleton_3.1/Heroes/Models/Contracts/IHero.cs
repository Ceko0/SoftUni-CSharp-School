﻿using System;

namespace Heroes.Models.Contracts
{
   public interface IHero : IComparable<IHero>
    {
        string Name { get; }

        int Health { get; }

        int Armour { get; }

        IWeapon Weapon { get; }

        bool IsAlive { get; }

        void TakeDamage(int points);

        void AddWeapon(IWeapon weapon);
    }
}

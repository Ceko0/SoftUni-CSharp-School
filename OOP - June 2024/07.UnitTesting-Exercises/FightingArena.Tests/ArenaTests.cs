using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ArenaCreateCorrect()
        {
            Arena arena = new Arena();
            Assert.IsEmpty(arena.Warriors);
        }

        [Test]
        public void ArenaCountShouldReturnCorrectCount()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Warrior1", 50, 100);
            Warrior warrior2 = new Warrior("Warrior2", 60, 100);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.AreEqual(2, arena.Count);
        }
        [Test]
        public void ArenaEnrollCorrect()
        {
            Warrior warrior = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Warrior warriorTwo = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Warrior warriorThree = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Arena arena = new();
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);
            arena.Enroll(warriorThree);
            Assert.AreEqual(3, arena.Count);
            var result = arena.Warriors;
            CollectionAssert.Contains(result, warrior);
            CollectionAssert.Contains(result, warriorTwo);
            CollectionAssert.Contains(result, warriorThree);
        }

        [Test]
        public void EnrollOneWarriorTwoTimes()
        {
            Warrior warrior = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Arena arena = new();
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void FightCantStartIfOneWarriorIsntEnroll()
        {
            Warrior warrior = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Warrior warriorTwo = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Arena arena = new();
            arena.Enroll(warrior);
            string firstName = warrior.Name;
            string secondName = warriorTwo.Name;
            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstName, secondName));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(secondName, firstName));
        }
        [Test]
        public void FightCantStartIfTwoWarriorsIsntEnroll()
        {
            Warrior warrior = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Warrior warriorTwo = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Arena arena = new();
            string firstName = warrior.Name;
            string secondName = warriorTwo.Name;
            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstName, secondName));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(secondName, firstName));

        }

        [Test]
        public void FightGoCorrect()
        {
            int firstDamage = Random.Shared.Next(61, 20000);
            int secondDamage = firstDamage / 2;
            int firstHP = firstDamage * 3;
            int secondHp = firstHP / 2;
            int outputFirstHp = firstHP - secondDamage;
            int outputSecondHp = secondHp - firstDamage;
            Warrior warrior = new(Random.Shared.Next().ToString(), firstDamage, firstHP);
            Warrior warriorTwo = new(Random.Shared.Next().ToString(), secondDamage, secondHp);
            Arena arena = new();
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);
            string firstName = warrior.Name;
            string secondName = warriorTwo.Name;
            arena.Fight(firstName, secondName);

            Assert.AreEqual(outputFirstHp, warrior.HP);
            Assert.AreEqual(outputSecondHp, warriorTwo.HP);
        }

        [Test]
        public void FightWhitOneWarrior()
        {
            Warrior warrior = new(Random.Shared.Next().ToString(), Random.Shared.Next(), Random.Shared.Next());
            Arena arena = new();
            arena.Enroll(warrior);
            string firstName = warrior.Name;
            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstName, firstName));
        }
    }
}

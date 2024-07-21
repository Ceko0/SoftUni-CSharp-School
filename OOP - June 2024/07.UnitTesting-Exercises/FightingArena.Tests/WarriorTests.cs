using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Xml.Linq;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase("asgd",1,1)]
        [TestCase("asadasa",int.MaxValue,int.MaxValue)]
        public void ConstructorWorkCorrect(string name ,int damage , int HP)
        {
            Warrior warrior = new(name,damage,HP);
            Assert.AreEqual(name,warrior.Name);
            Assert.AreEqual(damage,warrior.Damage);
            Assert.AreEqual(HP,warrior.HP);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void ConstructorThrowIfNameIsNullOrEmptyOrWitespace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 1, 1));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorThrowIfDamageIsZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("asdas", damage, 1));
        }
        
        [TestCase(-1)]
        public void ConstructorThrowIfHPIsNegative(int HP)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("asdas", 1, HP));
        }

        [Test]
        public void WarriorAttackWorkCorrect()
        {
            int firstDamage = Random.Shared.Next(61, 20000);
            int secondDamage = firstDamage / 2;
            int firstHP = firstDamage * 3;
            int secondHp = firstHP/2;
            int outputFirstHp = firstHP - secondDamage;
            int outputSecondHp = secondHp - firstDamage;
            Warrior warrior = new("asda", firstDamage,firstHP);
            Warrior warriorTwo = new("asdas", secondDamage, secondHp);
            warrior.Attack(warriorTwo);
            Assert.AreEqual(outputFirstHp,warrior.HP );
            Assert.AreEqual(outputSecondHp,warriorTwo.HP);
        }

        [Test]
        public void WarriorThrowIfHisHPIsUnderMinHP()
        {
            Warrior warrior = new("asda", 50, 29);
            Warrior warriorTwo = new("asda", 49, 30);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warriorTwo));
        }
        [Test]
        public void WarriorThrowIfEnemyHPIsUnderMinHP()
        {
            Warrior warrior = new("asda", 50, 31);
            Warrior warriorTwo = new("asda", 49, 29);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warriorTwo));
        } 
        [Test]
        public void WarriorThrowIfHisHPisLowThenEnemyDamage()
        {
            Warrior warrior = new("asda", 50, 31);
            Warrior warriorTwo = new("asda", 49, 31);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warriorTwo));
        }


    }
}
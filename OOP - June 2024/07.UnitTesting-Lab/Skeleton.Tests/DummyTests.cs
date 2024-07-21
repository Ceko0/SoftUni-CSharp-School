using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [SetUp]
        public void Creating ()
        {
           
        }
        
            Axe axe = new(10, 10);
        
        [Test]
        public void DummyCreatingCorrect()
        {
            int healt = Random.Shared.Next();
            int experience = Random.Shared.Next();
            Dummy dummy = new(healt,experience);
            
            Assert.AreEqual(healt , dummy.Health);
        }

        [Test]
        public void DummyLoseHealtIfAttacked()
        {
            int dummyHealt = 1000;
            Axe axe = new(10, 10);
            Dummy dummy = new(dummyHealt, 10);
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
                Assert.AreEqual(dummyHealt -= axe.AttackPoints,dummy.Health);
            }
        }

        [Test]
        public void throwExeptionIfDeadAndTakeAtack()
        {
            Dummy dummy = new(0, 10);
            Axe axe = new(10, 10);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }

        [Test]
        public void CanGiveXp()
        {
            Dummy dummy = new(0,10);
            Assert.AreEqual(10 ,dummy.GiveExperience());
        }

        [Test]
        public void CantGiveXPAndThrowExeption()
        {
            Dummy dummy = new(10, 10);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
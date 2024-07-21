using System;
using NUnit.Framework;

namespace Skeleton.Tests;

[TestFixture]
public class AxeTests
{
    [Test]
    public void CreatingAxeWhitValidParameters()
    {
        int atack = Random.Shared.Next();
        int durability = Random.Shared.Next();

        Axe axe = new(atack, durability);
        Assert.AreEqual(atack, axe.AttackPoints);
        Assert.AreEqual(durability, axe.DurabilityPoints);
    }

    [Test]
    public void AxeLooseDurabilityAfterEachAttack()
    {
        Axe axe = new(10, 10);
        Dummy dummy = new(1000, 10);
        for (int i = 0; i < 9; i++)
        {
            axe.Attack(dummy);
            Assert.AreEqual(9-i , axe.DurabilityPoints);
        }
    }
    [Test]
    public void AxeAtackWhitZeroDurability()
    {
        Axe axe = new(10, 0);
        Dummy dummy = new(1000, 10);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}


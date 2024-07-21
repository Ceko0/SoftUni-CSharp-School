using System;
using System.Collections.Generic;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void DatabaseCreateCorrectWhitMaxCapacity()
        {
            int[] maxCapacity = new int[16];
            for (int i = 0; i < 16; i++)
            {
                maxCapacity[i] = Random.Shared.Next();
            }
            Database database = new(maxCapacity);
            Assert.AreEqual(maxCapacity , database.Fetch());
        }

        [Test]
        public void DataBaseCreateCorrectWhitRandomCapacity()
        {
            int arrCapacity = Random.Shared.Next(0, 16);
            int [] randomCapacity = new int[arrCapacity];
            for (int i = 0; i < arrCapacity; i++)
            {
                randomCapacity[i] = Random.Shared.Next();
            }
            Database database = new(randomCapacity);
            Assert.AreEqual(randomCapacity , database.Fetch());
        }

        [Test]
        public void CountWorkCorrectly()
        {
            int arrCapacity = Random.Shared.Next(0, 16);
            int[] randomCapacity = new int[arrCapacity];
            for (int i = 0; i < arrCapacity; i++)
            {
                randomCapacity[i] = Random.Shared.Next();
            }
            Database database = new(randomCapacity);
            Assert.AreEqual(randomCapacity.Length , database.Count);
        }

        [Test]
        public void AddWorkCorrectInRightRange()
        {
            List<int> toCheck = new();
            Database database = new();
            for (int i = 0; i < 16; i++)
            {
                int number = Random.Shared.Next();
                database.Add(number);
                toCheck.Add(number);
                Assert.AreEqual(toCheck , database.Fetch());
            }
        }

        [Test]
        public void AddThrowIfDatabeseIsFull()
        {
            int[] maxCapacity = new int[16];
            for (int i = 0; i < 16; i++)
            {
                maxCapacity[i] = Random.Shared.Next();
            }
            Database database = new(maxCapacity);
            Assert.Throws<InvalidOperationException>(() => database.Add(Random.Shared.Next()));
        }

        [Test]
        public void RemoveWorkCorrect()
        {
            int arrCapacity = Random.Shared.Next(0, 16);
            int[] randomCapacity = new int[arrCapacity];
            List<int> toCheck = new();
            for (int i = 0; i < arrCapacity; i++)
            {
                int number = Random.Shared.Next();
                randomCapacity[i] = number;
                toCheck.Add(number);
            }
            Database database = new(randomCapacity);

            for (int i = 0; i < arrCapacity; i++)
            {
                database.Remove();
                toCheck.RemoveAt(toCheck.Count-1);
                Assert.AreEqual(toCheck , database.Fetch());
            }
        }

        [Test]
        public void RemoveThrowIfArrayIsEmpty()
        {
            Database database = new();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
    }
}

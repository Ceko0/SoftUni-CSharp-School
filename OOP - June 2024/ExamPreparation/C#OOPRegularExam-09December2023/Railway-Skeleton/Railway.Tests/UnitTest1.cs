namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private string name;
        private RailwayStation railway;
        [SetUp]
        public void Setup()
        {
            name = Random.Shared.Next().ToString();
            railway = new(name);
        }
        [Test]
        public void constructorWorkCorrectly()
        {
            string name = Random.Shared.Next().ToString();
            RailwayStation railway = new(name);
            Assert.That(name, Is.EqualTo(railway.Name));
            Assert.IsNotNull(railway.ArrivalTrains);
            Assert.IsNotNull(railway.DepartureTrains);
        }
        [TestCase (null)]
        [TestCase (" ")]
        [TestCase ("    ")]
        [TestCase ("")]
        public void ConstructorThrowIfNameIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() =>  new RailwayStation(name));
        }

        [Test]
        public void NewArrivalOnBoardCorrectly()
        {
            string name = Random.Shared.Next().ToString();
            railway.NewArrivalOnBoard(name);
            Assert.IsNotEmpty(railway.ArrivalTrains);
        }

        [Test]
        public void TrainHasArrivedReturnMSGIfTrainIsNotInList()
        {
            string name = Random.Shared.Next().ToString();
            string name2 = Random.Shared.Next().ToString();
            railway.NewArrivalOnBoard(name);
            Assert.That($"There are other trains to arrive before {name2}.", Is.EqualTo(railway.TrainHasArrived(name2)));
        }
        [Test]
        public void TrainHasArrivedReturnMSGIfTrainIsInList()
        {
            string name = Random.Shared.Next().ToString();
            
            railway.NewArrivalOnBoard(name);
            Assert.That($"{name} is on the platform and will leave in 5 minutes.", Is.EqualTo(railway.TrainHasArrived(name)));
        }

        [Test]
        public void TrainHasLeftReturnTrueIfTrainIsInList()
        {
            string name = Random.Shared.Next().ToString();
            railway.NewArrivalOnBoard(name);
            railway.TrainHasArrived(name);
            Assert.IsTrue(railway.TrainHasLeft(name));
            Assert.IsEmpty(railway.DepartureTrains);
        }
        [Test]
        public void TrainHasLeftReturnFalseIfTrainIsNotInList()
        {
            string name = Random.Shared.Next().ToString();
            string name2 = Random.Shared.Next().ToString();
            railway.NewArrivalOnBoard(name);
            railway.TrainHasArrived(name);
            Assert.IsFalse(railway.TrainHasLeft(name2));
            Assert.IsNotEmpty(railway.DepartureTrains);
        }
    }
}
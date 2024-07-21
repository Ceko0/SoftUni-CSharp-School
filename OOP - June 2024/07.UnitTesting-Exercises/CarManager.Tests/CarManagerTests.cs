using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase(null, "abs", 2.2, 2.3)]
        [TestCase("", "abs", 2.2, 2.3)]
        [TestCase("abs", null, 2.2, 2.3)]
        [TestCase("abs", "", 2.2, 2.3)]
        [TestCase("abs", "adss", 0, 2.3)]
        [TestCase("abs", "adss", 2.2, 0)]
        public void ConstructorThrowCorrectWhit(string make, string model, double fuelConsumption, double fuelCapacity)
        {

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ConstructorWorkCorrect()
        {
            string make, model;
            double fuelConsumption, fuelCapacity;
            Car car;
            CreateNewCarWhitAttributes(out make, out model, out fuelConsumption, out fuelCapacity, out car);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void FuelAmountWorkCorrect()
        {
            double randomDouble = Random.Shared.NextDouble();
            Car car = CreateNewCar();
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1.0)]
        [TestCase(-231321.12)]
        [TestCase(-12)]
        public void FuelAmountThrowIfInputIsZeroOrNegative(double fuelAmount)
        {
            Car car = CreateNewCar();
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));
        }

        [Test]
        public void FuelAmountDontGoOVerCapacity()
        {
            Car car = CreateNewCar();
            double fuelAmount = car.FuelCapacity+ 10;
            car.Refuel(fuelAmount);
            Assert.AreEqual(car.FuelCapacity , car.FuelAmount);
        }

        [Test]
        public void DriveWorkCorrect()
        {
            Car car = new("asda", "asdass", 10, 500);
            car.Refuel(500);
            car.Drive(100);
            Assert.AreEqual(490 , car.FuelAmount);
        }

        [Test]
        public void DriveThrowWhenNoFuel()
        {
            Car car = new("asda", "asdass", 10, 500);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }
        private static Car CreateNewCar()
        {
            string make = Random.Shared.Next().ToString();
            string model = Random.Shared.Next().ToString();
            double fuelConsumption = Random.Shared.NextDouble();
            double fuelCapacity = Random.Shared.NextDouble();
            Car car = new(make, model, fuelConsumption, fuelCapacity);
            return car;
        }

        private void CreateNewCarWhitAttributes(out string make, out string model, out double fuelConsumption,
            out double fuelCapacity, out Car car)
        {
            make = Random.Shared.Next().ToString();
            model = Random.Shared.Next().ToString();
            fuelConsumption = Random.Shared.NextDouble();
            fuelCapacity = Random.Shared.NextDouble();
            car = new(make, model, fuelConsumption, fuelCapacity);
        }
    }

}
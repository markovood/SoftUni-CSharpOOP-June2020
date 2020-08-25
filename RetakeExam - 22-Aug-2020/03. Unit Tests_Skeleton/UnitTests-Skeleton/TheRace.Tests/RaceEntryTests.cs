using System;

using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private const string DriverAdded = "Driver {0} added in race.";
        private const string DriverInvalid = "Driver cannot be null.";
        private const string ExistingDriver = "Driver {0} is already added.";

        private UnitDriver unitDriver;
        private UnitCar unitCar;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.unitCar = new UnitCar("Opel", 90, 1400);
            this.unitDriver = new UnitDriver("Pesho", this.unitCar);

            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void UnitDriver_Name_ShouldThrowArgumentNullExceptionWhenSettingWithNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new UnitDriver(null, this.unitCar));
        }

        [Test]
        public void UnitDriver_Name_ShouldReturnCorrectName()
        {
            Assert.AreEqual("Pesho", this.unitDriver.Name);
        }

        [Test]
        public void Constructor_ShouldInitializeInnerDictionary()
        {
            Assert.Zero(this.raceEntry.Counter);
        }

        [Test]
        public void Count_ShouldReturnCorrectCount()
        {
            this.raceEntry.AddDriver(this.unitDriver);

            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void AddDriver_ShouldReturnCorrectString()
        {
            string expected = string.Format(DriverAdded, this.unitDriver.Name);
            string actual = this.raceEntry.AddDriver(this.unitDriver);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddDriver_ShouldThrowInvalidOperationExceptionWhenDriverIsNull()
        {
            Assert.That(
                () => this.raceEntry.AddDriver(null),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo(DriverInvalid));
        }

        [Test]
        public void AddDriver_ShouldThrowInvalidOperationExceptionWhenDriverIsAlreadyAdded()
        {
            this.raceEntry.AddDriver(this.unitDriver);

            Assert.That(
                () => this.raceEntry.AddDriver(this.unitDriver),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo(string.Format(ExistingDriver, this.unitDriver.Name)));
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldReturnCorrectAverageHorsePower()
        {
            this.raceEntry.AddDriver(this.unitDriver);
            var otherUnitDriver = new UnitDriver("Gosho", new UnitCar("Honda", 89, 1356));
            this.raceEntry.AddDriver(otherUnitDriver);
            double expected = 89.5;

            double actual = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldThrowInvalidOperationExceptionWhenCounterIsLessThanTwo()
        {
            this.raceEntry.AddDriver(this.unitDriver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }
    }
}
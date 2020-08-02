using CarManager;

using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private string carMake;
        private string carModel;
        private double fuelConsumption;
        private double fuelCapacity;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.carMake = "Opel";
            this.carModel = "Meriva";
            this.fuelConsumption = 6.5;
            this.fuelCapacity = 60.0;
            this.car = new Car(this.carMake, this.carModel, this.fuelConsumption, this.fuelCapacity);
        }

        [Test]
        public void ConstructorShouldSetAllPropertiesCorrectly()
        {
            string expectedMake = this.carMake;
            string expectedModel = this.carModel;
            double expectedFuelConsumption = this.fuelConsumption;
            double expectedFuelCapacity = this.fuelCapacity;
            double expectedFuelAmount = 0.0;

            string actualMake = this.car.Make;
            string actualModel = this.car.Model;
            double actualFuelConsumption = this.car.FuelConsumption;
            double actualFuelCapacity = this.car.FuelCapacity;
            double actualFuelAmount = this.car.FuelAmount;

            Assert.Multiple(() =>
                {
                    Assert.AreEqual(expectedMake, actualMake, "Make was not set correctly!");
                    Assert.AreEqual(expectedModel, actualModel, "Model was not set correctly!");
                    Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption, "FuelConsumption was not set correctly!");
                    Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity, "FuelCapacity was not set correctly!");
                    Assert.AreEqual(expectedFuelAmount, actualFuelAmount, "FuelAmount was not set correctly!");
                });
        }

        [Test]
        public void SettingMakeWithNullOrEmptyShouldThrowArgumentException()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                () => new Car(null, this.carModel, this.fuelConsumption, this.fuelCapacity),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Make cannot be null or empty!"),
                "Make was set to null");

                Assert.That(
                () => new Car("", this.carModel, this.fuelConsumption, this.fuelCapacity),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Make cannot be null or empty!"),
                "Make was set to empty");
            });
        }

        [Test]
        public void SettingModelWithNullOrEmptyShouldThrowArgumentException()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                () => new Car(this.carMake, null, this.fuelConsumption, this.fuelCapacity),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Model cannot be null or empty!"),
                "Model was set to null");

                Assert.That(
                () => new Car(this.carModel, "", this.fuelConsumption, this.fuelCapacity),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Model cannot be null or empty!"),
                "Model was set to empty");
            });
        }

        [Test]
        public void SettingFuelConsumptionWithZeroOrLessShouldThrowArgumentException()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                () => new Car(this.carMake, this.carModel, 0, this.fuelCapacity),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Fuel consumption cannot be zero or negative!"),
                "FuelConsumption was set to 0");

                Assert.That(
                () => new Car(this.carModel, this.carModel, -5, this.fuelCapacity),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Fuel consumption cannot be zero or negative!"),
                "FuelConsumption was set to negative value");
            });
        }

        [Test]
        public void SettingFuelCapacityWithZeroOrLessShouldThrowArgumentException()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                () => new Car(this.carMake, this.carModel, this.fuelConsumption, 0),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Fuel capacity cannot be zero or negative!"),
                "FuelCapacity was set to 0");

                Assert.That(
                () => new Car(this.carModel, this.carModel, this.fuelConsumption, -60),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Fuel capacity cannot be zero or negative!"),
                "FuelCapacity was set to negative value");
            });
        }

        [Test]
        public void RefuelShouldThrowArgumentExceptionWhenAmountOfFuelToAddIsZeroOrNegative()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                    () => this.car.Refuel(0),
                    Throws
                     .ArgumentException
                     .With
                     .Message
                     .EqualTo("Fuel amount cannot be zero or negative!"),
                    "Car was refueled with 0");
                
                Assert.That(
                    () => this.car.Refuel(-5),
                    Throws
                     .ArgumentException
                     .With
                     .Message
                     .EqualTo("Fuel amount cannot be zero or negative!"),
                    "Car was refueled with negative value");
            });
        }

        [Test]
        public void RefuelShouldIncreaseFuelAmountWithRefueledAmount()
        {
            double amountToRefuel = 15;
            double expectedFuelAmount = amountToRefuel;

            this.car.Refuel(amountToRefuel);
            double actualFuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void RefuelingWithMoreFuelThanTheCarCapacitySouldSetFuelAmountToFuelCapacityAmount()
        {
            double amountToRefuel = this.car.FuelCapacity + 15;
            double expectedFuelAmount = this.car.FuelCapacity;

            this.car.Refuel(amountToRefuel);
            double actualFuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void DriveShouldThrowInvalidOperationExceptionWhenNotEnoughFuelForTheDistance()
        {
            Assert.That(
                () => this.car.Drive(10),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void DriveShouldReduceFuelAmountWithFuelNeededToPassTheDistance()
        {
            double litersFor100Km = 6.5;
            this.car.Refuel(litersFor100Km);
            double expectedFuelAmount = 0;

            this.car.Drive(100);
            double actualFuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
    }
}
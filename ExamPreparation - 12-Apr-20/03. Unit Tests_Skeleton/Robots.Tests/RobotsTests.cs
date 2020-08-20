namespace Robots.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager manager;
        private Robot robot;

        [SetUp]
        public void SetUp()
        {
            this.manager = new RobotManager(5);
            this.robot = new Robot("Pesho", 100);
        }

        [Test]
        public void Constructor_ShouldInitializeInnerCollection()
        {
            int expectedCount = 0;

            int actualCount = this.manager.Count;

            Assert.AreEqual(expectedCount, actualCount, "Inner collection is not initialized!");
        }

        [Test]
        public void Constructor_ShouldSetCapacityCorrectly()
        {
            int expectedCapacity = 5;

            int actualCapacity = this.manager.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void Capacity_ShouldThrowArgumentExceptionWhenSettingWithNegative()
        {
            int negativeCapacity = -5;

            Assert.That(
                () => new RobotManager(negativeCapacity),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Invalid capacity!"));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationExceptionWhenAddingExistingRobot()
        {
            this.manager.Add(this.robot);

            Assert.That(
                () => this.manager.Add(this.robot),
                Throws
                .InvalidOperationException
                .With
                .Message
                .Contains("There is already a robot with name"));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationExceptionWhenCapacityIsFull()
        {
            var manager = new RobotManager(1);
            manager.Add(this.robot);
            var otherRobot = new Robot("Gosho", 150);

            Assert.That(
                () => manager.Add(otherRobot),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Not enough capacity!"));
        }

        [Test]
        public void Add_ShouldAddGivenRobot()
        {
            int expectedCount = 1;

            this.manager.Add(this.robot);
            int actualCount = this.manager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationExceptionWhenGivenRobotNotFound()
        {
            Assert.That(
                () => this.manager.Remove(this.robot.Name),
                Throws
                .InvalidOperationException
                .With
                .Message
                    .StartsWith("Robot with the name ")
                    .And
                        .Message
                        .EndsWith(" doesn't exist!"));
        }

        [Test]
        public void Remove_ShouldRemoveGivenRobot()
        {
            this.manager.Add(this.robot);
            int expectedCount = 0;

            this.manager.Remove(this.robot.Name);
            int actualCount = this.manager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Work_ShouldThrowInvalidOperationExceptionWhenRobotDoesntExist()
        {
            Assert.That(
                () => this.manager.Work(this.robot.Name, "clean", 45),
                Throws
                .InvalidOperationException
                .With
                .Message
                .StartWith("Robot with the name ")
                    .And
                    .Message
                    .EndsWith(" doesn't exist!"));
        }

        [Test]
        public void Work_ShouldThrowInvalidOperationExceptionWhenGivenRobotBatteryIsLessThanBatteryUsage()
        {
            this.manager.Add(this.robot);

            Assert.That(
                () => this.manager.Work(this.robot.Name, "clean", 101),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EndsWith(" doesn't have enough battery!"));
        }

        [Test]
        public void Work_ShouldReduceRobotBatteryWithGivenBatteryUsage()
        {
            this.manager.Add(this.robot);
            int expectedBattery = 50;

            this.manager.Work(this.robot.Name, "clean", 50);
            int actualBattery = this.robot.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void Charge_ShouldThrowInvalidOperationExceptionWhenRobotDoesntExist()
        {
            Assert.That(
                () => this.manager.Charge(this.robot.Name),
                Throws
                .InvalidOperationException
                .With
                .Message
                .StartWith("Robot with the name ")
                    .And
                    .Message
                    .EndsWith(" doesn't exist!"));
        }

        [Test]
        public void Charge_ShouldChargeRobotBatteryToMax()
        {
            this.manager.Add(this.robot);
            this.manager.Work(this.robot.Name, "clean", 25);
            int expectedBattery = 100;

            this.manager.Charge(this.robot.Name);
            int actualBattery = this.robot.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }
    }
}

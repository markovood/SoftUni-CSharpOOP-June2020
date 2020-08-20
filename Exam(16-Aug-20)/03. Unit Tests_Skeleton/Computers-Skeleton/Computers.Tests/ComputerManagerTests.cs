using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.computerManager = new ComputerManager();
            this.computer = new Computer("Asus", "ROG", 1500m);
        }

        [Test]
        public void Constructor_ShouldInitializeCollection()
        {
            Assert.IsNotNull(this.computerManager.Computers);
        }

        [Test]
        public void Count_ShouldReturnCorrectCount()
        {
            this.computerManager.AddComputer(this.computer);
            int expected = 1;

            int actual = this.computerManager.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddComputer_ShouldThrowArgumentNullExceptionWhenAddingNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputer_ShouldThrowArgumentExceptionWhenAddingComputerThatExists()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.That(
                () => this.computerManager.AddComputer(this.computer),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("This computer already exists."));
        }

        [Test]
        public void AddComputer_ShouldAddComputer()
        {
            int expectedCount = 1;

            this.computerManager.AddComputer(this.computer);
            int actualCount = this.computerManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddComputer_ShouldAddGivenComputer()
        {
            var expectedComp = this.computer;

            this.computerManager.AddComputer(this.computer);

            Assert.IsTrue(this.computerManager.Computers.Contains(this.computer));
        }

        [Test]
        public void RemoveComputer_ShouldRemoveComputerWithGivenManufacturerAndModel()
        {
            this.computerManager.AddComputer(this.computer);
            var expectedComp = this.computer;

            var actualComp = this.computerManager.RemoveComputer(this.computer.Manufacturer, this.computer.Model);
            //Assert.AreSame(expectedComp, actualComp);
            Assert.AreEqual(expectedComp, actualComp);
        }

        [Test]
        public void RemoveComputer_ShouldRemoveTheCorrectComputerWithGivenManufacturerAndModel()
        {
            this.computerManager.AddComputer(this.computer);
            var expectedComp = this.computer;

            this.computerManager.RemoveComputer(this.computer.Manufacturer, this.computer.Model);
            
            CollectionAssert.DoesNotContain(this.computerManager.Computers, expectedComp);
        }

        [Test]
        public void GetComputer_ShouldThrowArgumentNullExceptionWhenGivenNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(null, "ROG"));
        }

        [Test]
        public void GetComputer_ShouldThrowArgumentNullExceptionWhenGivenNullModel()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer("Asus", null));
        }

        [Test]
        public void GetComputer_ShouldThrowArgumentExceptionWhenComputerDoesntExist()
        {
            Assert.That(
                () => this.computerManager.GetComputer("nqkoi", "nqma"),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("There is no computer with this manufacturer and model."));
        }

        [Test]
        public void GetComputer_ShouldReturnComputerWithGivenManufacturerAndModel()
        {
            this.computerManager.AddComputer(this.computer);
            var expected = this.computer;

            var actual = this.computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.AreSame(expected, actual);
        }

        [Test]
        public void GetComputersByManufacturer_ShouldThrowArgumentNullExceptionWhenGivenNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnCollectionOfAllCompsWithGivenManufacturer()
        {
            this.computerManager.AddComputer(this.computer);
            var comp = new Computer("Asus", "K54HR", 1000m);
            this.computerManager.AddComputer(comp);
            var otherComp = new Computer("IBM", "model", 1300m);
            this.computerManager.AddComputer(otherComp);
            ICollection<Computer> expectedCollection = new List<Computer>()
            {
                this.computer,
                comp
            };

            var actualCollection = this.computerManager.GetComputersByManufacturer("Asus");

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnEmptyCollectionWhenNoComputersWithGivenManufacturer()
        {
            this.computerManager.AddComputer(this.computer);
            var comp = new Computer("Asus", "K54HR", 1000m);
            this.computerManager.AddComputer(comp);
            var otherComp = new Computer("IBM", "model", 1300m);
            this.computerManager.AddComputer(otherComp);

            var collection = this.computerManager.GetComputersByManufacturer("Toshiba");

            CollectionAssert.IsEmpty(collection);
        }
    }
}
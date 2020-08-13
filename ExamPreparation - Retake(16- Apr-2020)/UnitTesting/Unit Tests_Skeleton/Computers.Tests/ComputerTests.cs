namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        private Computer computer;
        private Part partToAdd;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("ASUS");
            string partName = "RAM";
            decimal partPrice = 5.0m;
            this.partToAdd = new Part(partName, partPrice);
        }

        [Test]
        public void ConstructorShouldSetAllPropertiesCorrectly()
        {
            string expectedName = "ASUS";

            string actualName = this.computer.Name;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedName, actualName);
                Assert.IsNotNull(this.computer.Parts);
            });
        }

        [TestCase(null)]
        [TestCase("   ")]
        public void NameShouldThrowArgumentNullExceptionWhenSetWithNullOrWhiteSpace(string name)
        {
            Assert.That(
                () => new Computer(name),
                Throws
                .ArgumentNullException
                .With
                .Message
                .Contains("Name cannot be null or empty!"));
        }

        [Test]
        public void AddPartShouldThrowInvalidOpeationExceptionWhenAddedPatIsNull()
        {
            Part partToAdd = null;

            Assert.That(
                () => this.computer.AddPart(partToAdd),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Cannot add null!"));
        }

        [Test]
        public void AddPartShouldAddTheGivenPartToComputerPatsCollection()
        {
            int expectedPartsCount = 1;

            this.computer.AddPart(this.partToAdd);
            int actualPartsCount = this.computer.Parts.Count;

            Assert.AreEqual(expectedPartsCount, actualPartsCount);
        }

        [Test]
        public void TotalPriceShouldReturnTheSumOfAllPatsPrices()
        {
            decimal expectedTotalPrice = 10.0m;

            this.computer.AddPart(this.partToAdd);
            this.computer.AddPart(this.partToAdd);
            decimal actualTotalPrice = this.computer.TotalPrice;

            Assert.AreEqual(expectedTotalPrice, actualTotalPrice);
        }

        [Test]
        public void RemovePartShouldRemoveGivenPart()
        {
            Part partToRemove = this.partToAdd;
            int expectedCount = 0;

            this.computer.RemovePart(partToRemove);
            int actualCount = this.computer.Parts.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemovePartShouldReturnFalseWhenNoSuchPart()
        {
            Part unexistingPart = new Part("SHHHH", 2.0m);

            Assert.IsFalse(this.computer.RemovePart(unexistingPart));
        }

        [Test]
        public void GetPartsShouldReturnNullWhenNoSuchPartExists()
        {
            string unexistingPart = "NqmaTAkovaNeshto";

            Assert.IsNull(this.computer.GetPart(unexistingPart));
        }

        [Test]
        public void GetPartsShouldReturnTheGivenPart()
        {
            this.computer.AddPart(this.partToAdd);
            Part expectedPart = this.partToAdd;

            Part actualPart = this.computer.GetPart(this.partToAdd.Name);

            Assert.AreEqual(expectedPart, actualPart);
        }
    }
}
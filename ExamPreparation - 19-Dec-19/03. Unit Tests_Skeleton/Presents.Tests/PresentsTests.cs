namespace Presents.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]
        public void Set()
        {
            this.bag = new Bag();
            this.present = new Present("toy", 6.5);
        }

        [Test]
        public void Constructor_ShouldInitializeInnerCollection()
        {
            Assert.IsNotNull(this.bag.GetPresents());
        }

        [Test]
        public void Create_ShouldThrowArgumentNullExceptionWhenPresentNull()
        {
            Assert.That(
                () => this.bag.Create(null),
                Throws
                .ArgumentNullException
                .With
                .Message
                .Contains("Present is null"));
        }

        [Test]
        public void Create_ShouldThrowInvalidOperationExceptionWhenPresentExists()
        {
            this.bag.Create(this.present);

            Assert.That(
                () => this.bag.Create(this.present),
                Throws
                .InvalidOperationException
                .With
                .Message
                .Contains("This present already exists!"));
        }

        [Test]
        public void Create_ShouldAddPresentToBag()
        {
            this.bag.Create(this.present);

            CollectionAssert.Contains(this.bag.GetPresents(), this.present);
        }

        [Test]
        public void Create_ShouldReturnCorrectMsgWhenSuccessful()
        {
            string expected = $"Successfully added present {this.present.Name}.";
            string actual = this.bag.Create(this.present);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_ShouldReturnTrueWhenSuccessfullyRemoved()
        {
            this.bag.Create(this.present);

            Assert.IsTrue(this.bag.Remove(this.present));
        }

        [Test]
        public void Remove_ShouldReturnFalseWhenUnsuccessfullyRemoved()
        {
            Assert.IsFalse(this.bag.Remove(this.present));
        }

        [Test]
        public void Remove_ShouldRemoveCorrectPresent()
        {
            this.bag.Create(this.present);

            this.bag.Remove(this.present);

            CollectionAssert.DoesNotContain(this.bag.GetPresents(), this.present);
        }

        [Test]
        public void GetPresent_ShouldReturnNullWhenPresentNotFound()
        {
            Assert.IsNull(this.bag.GetPresent("invalid"));
        }

        [Test]
        public void GetPresent_ShouldReturnCorrectPresent()
        {
            this.bag.Create(this.present);
            Present expected = this.present;

            Present actual = this.bag.GetPresent(this.present.Name);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentWithLeastMagic_ShouldThrowExceptionWhenBagIsEmpty()
        {
            Assert.That(
                () => this.bag.GetPresentWithLeastMagic(),
                Throws
                .InvalidOperationException);
        }

        [Test]
        public void GetPresentWithLeastMagic_ShouldReturnCorrectPresent()
        {
            this.bag.Create(this.present);
            Present otherPresent = new Present("name", 4.5);
            this.bag.Create(otherPresent);
            Present expected = otherPresent;

            Present actual = this.bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expected, actual);
        }
    }
}
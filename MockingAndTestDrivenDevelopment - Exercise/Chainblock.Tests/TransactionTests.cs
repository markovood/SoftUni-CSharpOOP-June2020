using System;

using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private int id;
        private TransactionStatus status;
        private string from;
        private string to;
        private double amount;
        private Transaction transaction;

        [SetUp]
        public void Setup()
        {
            this.id = 1;
            this.status = TransactionStatus.Successfull;
            this.from = "Gosho";
            this.to = "Pesho";
            this.amount = 750;
            this.transaction = new Transaction(id, status, from, to, amount);
        }

        [Test]
        public void ConstructorShouldSetAllPropertiesCorrectly()
        {
            int expectedId = this.id;
            TransactionStatus expectedStatus = this.status;
            string expectedFrom = this.from;
            string expectedTo = this.to;
            double expectedAmount = this.amount;

            int actualId = this.transaction.Id;
            TransactionStatus actualStatus = this.transaction.Status;
            string actualFrom = this.transaction.From;
            string actualTo = this.transaction.To;
            double actualAmount = this.transaction.Amount;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedId, actualId, "ID was not set correctly");
                Assert.AreEqual(expectedStatus, actualStatus, "TransactionStatus was not set correctly");
                Assert.AreEqual(expectedFrom, actualFrom, "From was not set correctly");
                Assert.AreEqual(expectedTo, actualTo, "To was not set correctly");
                Assert.AreEqual(expectedAmount, actualAmount, "Amount was not set correctly");
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void IdShouldThrowArgumentOutOfRangeExceptionWhenSetWithNegativeOrZero(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
            () => new Transaction(
                        id,
                        this.status,
                        this.from,
                        this.to,
                        this.amount));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void FromShouldThrowArgumentNullExceptionWhenSettingWithNullEmptyOrWhiteSpace(string from)
        {
            Assert.Throws<ArgumentNullException>(
            () => new Transaction(this.id, this.status, from, this.to, this.amount));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ToShouldThrowArgumentNullExceptionWhenSettingWithNullEmptyOrWhiteSpace(string to)
        {
            Assert.Throws<ArgumentNullException>(
                () => new Transaction(this.id, this.status, this.from, to, this.amount));
        }

        [TestCase(0)]
        [TestCase(-500.50)]
        public void AmountShouldThrowArgumentOutfRangeExceptionWhenSetToZeroOrNegative(double amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Transaction(this.id, this.status, this.from, this.to, amount));
        }
    }
}
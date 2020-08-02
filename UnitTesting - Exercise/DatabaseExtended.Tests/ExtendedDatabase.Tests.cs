using System;

using ExtendedDatabase;

using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private const int DB_MAX_COUNT = 16;

        private ExtendedDatabase.ExtendedDatabase db;
        private Person pesho;

        [SetUp]
        public void Setup()
        {
            this.pesho = new Person(1l, "Pesho");
            Person[] people = new Person[3] 
            {
                this.pesho,
                new Person(2l, "Gosho"),
                new Person(3l, "Ivan")
            };

            this.db = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void AddOperationShouldAddElementAtTheNextFreeCell()
        {
            int expectedCount = 4;
            Person personToAdd = new Person(4l, "Stamat");

            this.db.Add(personToAdd);
            int actualCount = this.db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenAddingSeventeenthElement()
        {
            long id = 4l;
            int namePostFix = 1;
            for (int i = this.db.Count; i < DB_MAX_COUNT; i++)
            {
                this.db.Add(new Person(id, $"Stamat{namePostFix}"));
                id++;
                namePostFix++;
            }

            Person personToAdd = new Person(17l, "Genadi");

            Assert.That(
                () => this.db.Add(personToAdd),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenUsernameIsNotUnique()
        {
            Assert.That(
                () => this.db.Add(this.pesho),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenIdIsNotUnique()
        {
            var person = new Person(1L, "Misho");
            Assert.That(
                () => this.db.Add(person),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveShouldRemoveTheElementAtTheLastIndex()
        {
            int expectedCount = 2;

            this.db.Remove();
            int actualCount = this.db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionWhenRemovingFromEmptyDB()
        {
            int dbSize = this.db.Count;
            for (int i = 0; i < dbSize; i++)
            {
                this.db.Remove();
            }

            Assert.That(
                () => this.db.Remove(),
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameShouldReturnThePersonWithThatUsername()
        {
            string username = "Pesho";
            Person expectedPerson = this.pesho;

            Person actualPerson = this.db.FindByUsername(username);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByUsernameShouldThrowArgumentNullExceptionWhenUsernameIsNullOrEmpty()
        {
            string username = null;

            Assert.That(
                () => this.db.FindByUsername(username),
                Throws
                 .ArgumentNullException
                 .With
                 .Message
                 .Contains("Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameShouldThrowInvalidOperationExceptionWhenUsernameIsNotFound()
        {
            string notExistingUsername = "Stamo";

            Assert.That(
                () => this.db.FindByUsername(notExistingUsername),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByIdShouldReturnPersonWithThatId()
        {
            Person expectedPerson = this.pesho;

            Person actualPerson = this.db.FindById(1l);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByIdShouldThrowArgumentOutOfRangeExceptionWhenNegativeId()
        {
            long negativeId = -5l;

            Assert.Throws<ArgumentOutOfRangeException>(
                () => this.db.FindById(negativeId));
        }

        [Test]
        public void FindByIdShouldThrowInvalidOperationExceptionWhenIdIsNotFoud()
        {
            long notExistingId = 50l;

            Assert.That(
                () => this.db.FindById(notExistingId),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("No user is present by this ID!"));
        }
    }
}
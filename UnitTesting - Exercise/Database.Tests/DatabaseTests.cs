using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private const int DB_MAX_COUNT = 16;

        private Database.Database db;
        private int elementToAdd;

        [SetUp]
        public void Setup()
        {
            int[] elements = new int[3] { 1, 2, 3 };
            this.db = new Database.Database(elements);
            this.elementToAdd = 4;
        }

        [Test]
        public void AddOperationShouldAddElementAtTheNextFreeCell()
        {
            int expectedCount = 4;

            this.db.Add(this.elementToAdd);
            int actualCount = this.db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenAddingSeventeenthElement()
        {
            for (int i = this.db.Count; i < DB_MAX_COUNT; i++)
            {
                this.db.Add(this.elementToAdd);
            }

            Assert.That(
                () => this.db.Add(this.elementToAdd),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("Array's capacity must be exactly 16 integers!"));
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
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("The collection is empty!"));
        }

        [Test]
        public void FetchShouldReturnAllElementsAsArray()
        {
            int[] expectedElements = new int[3] { 1, 2, 3 };

            int[] actualElements = this.db.Fetch();

            Assert.AreEqual(expectedElements, actualElements);
        }
    }
}
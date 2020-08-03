namespace INStock.Tests
{
    using System;
    using System.Collections.Generic;

    using INStock.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        private ProductStock stock;
        private Product product;

        [SetUp]
        public void Setup()
        {
            this.stock = new ProductStock();
            this.product = new Product("someLabel", 10m, 1);

            this.stock.Add(this.product);
        }

        [Test]
        public void AddShouldThrowArgumentNullExceptionWhenAddingProductWithNullValue()
        {
            Assert
                .That(
                () => this.stock.Add(null),
                Throws
                .ArgumentNullException
                .With
                .Message
                .Contains("Null values cannot be added!"));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenAddingProductWithLabelThatExists()
        {
            Product exsistingProduct = this.product;

            Assert
                .That(
                () => this.stock.Add(exsistingProduct),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Product's label must be unique!"));
        }

        [Test]
        public void AddShouldAddTheNewManufacturedProductInStock()
        {
            Assert.IsTrue(this.stock.Contains(this.product));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenProductIsNotInStock()
        {
            Product unexistingProduct = new Product("Non-existing", 1m, 1);
            Assert.IsFalse(this.stock.Contains(unexistingProduct));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenProductIsInStock()
        {
            Product existingProduct = this.product;

            Assert.IsTrue(this.stock.Contains(existingProduct));
        }

        [Test]
        public void CountShouldReturnTheNumberOfProductsCurrentlyInStock()
        {
            int expectedCount = 1;

            int actualCount = this.stock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void IndexerShouldReturnCorrectProductAccordingToTheIndexPassed()
        {
            var expectedProduct = this.product;

            var actualProduct = this.stock[0];

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        [Test]
        public void IndexerShouldSetCorrectProductToTheIndexPassed()
        {
            var testProduct = new Product("testLabel", 5m, 1);
            var expectedProduct = testProduct;

            this.stock[0] = testProduct;
            var actualProduct = this.stock[0];

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        [Test]
        public void IndexerShouldThrowExceptionWhenSettingNegativeOrNonExistingIndex()
        {
            var testProduct = new Product("testLabel", 5m, 1);

            Assert.Throws<IndexOutOfRangeException>(
                            () => this.stock[-5] = testProduct);
        }

        [Test]
        public void FindShouldReturnProductAccordingToTheIndexPassed()
        {
            var expectedProduct = this.product;

            var actualProduct = this.stock.Find(0);

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        [Test]
        public void FindShouldThrowIndexOutOfRangeExceptionWhenLookingForNegativeOrNonExistingIndex()
        {
            int negativeIndex = -5;

            Assert.Throws<IndexOutOfRangeException>(
                            () => this.stock.Find(negativeIndex));
        }

        [Test]
        public void FindByLabelShouldReturnCorrectProduct()
        {
            string labelToFind = this.product.Label;
            var expectedProduct = this.product;

            var actualProduct = this.stock.FindByLabel(labelToFind);

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        [Test]
        public void FindByLabelShouldThrowArgumentNullExceptionWhenLabelToFindIsNull()
        {
            string nullLabel = null;

            Assert.Throws<ArgumentNullException>(
                            () => this.stock.FindByLabel(nullLabel));
        }

        [Test]
        public void FindByLabelShouldThrowArgumentExceptionWhenProductNotFound()
        {
            string unexistingLabel = "NoSuchLabel";

            Assert
                .That(
                () => this.stock.FindByLabel(unexistingLabel),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("No such product is in stock!"));
        }

        [Test]
        public void FindAllInRangeShouldReturnCollectionWithAllProductsInTheGivenPriceRangeInDescendingOrder()
        {
            var product1 = new Product("label1", 15m, 1);
            var product2 = new Product("label2", 20m, 1);
            var product3 = new Product("label3", 25m, 1);
            var product4 = new Product("label4", 30m, 1);

            this.stock.Add(product1);
            this.stock.Add(product2);
            this.stock.Add(product3);
            this.stock.Add(product4);


            var expectedCollection = new List<IProduct>()
            {
                product4,
                product3,
                product2,
                product1
            };

            var actualCollection = this.stock.FindAllInRange(15, 30);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void FindAllInRangeShouldReturnEmptyCollectionWhenNoProductsFound()
        {
            CollectionAssert.IsEmpty(this.stock.FindAllInRange(15, 30));
        }

        [Test]
        public void FindAllByPriceShouldReturnCollectionOfAllProductsInStockWithGivenPrice()
        {
            var product = new Product("label", 15m, 1);
            this.stock.Add(product);
            var otherProduct = new Product("otherLabel", 15m, 1);
            this.stock.Add(otherProduct);
            var expectedCollection = new List<IProduct>()
            {
                product,
                otherProduct
            };

            var actualCollection = this.stock.FindAllByPrice(15);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void FindAllByPriceShouldReturnEmptyCollectionWhenNoProductsFound()
        {
            CollectionAssert.IsEmpty(this.stock.FindAllByPrice(15));
        }

        [Test]
        public void FindMostExpensiveShouldReturnCorrectProduct()
        {
            var expensiveProduct = new Product("luxProd", 150m, 1);
            this.stock.Add(expensiveProduct);
            var expectedProduct = expensiveProduct;

            var actualProduct = this.stock.FindMostExpensiveProduct();

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        [Test]
        public void FindMostExpensiveShouldReturnNullWhenNoProductsInStock()
        {
            Assert.IsNull(new ProductStock().FindMostExpensiveProduct());
        }

        [Test]
        public void FindAllByQuantityShouldReturnallCollectionOfAllProductsInStockWithGivenRemainingQuantity()
        {
            var product = new Product("label", 15m, 1);
            this.stock.Add(product);
            var otherProduct = new Product("otherLabel", 15m, 3);
            this.stock.Add(otherProduct);
            var anotherProduct = new Product("anotherLabel", 15m, 5);
            this.stock.Add(anotherProduct);

            var expectedCollection = new List<IProduct>()
            {
                this.product,
                product
            };

            var actualCollection = this.stock.FindAllByQuantity(1);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void FindAllByQuantityShouldReturnallEmptyCollectionWhenNoProductsFound()
        {
            CollectionAssert.IsEmpty(this.stock.FindAllByQuantity(10));
        }

        [Test]
        public void GetEnumeratorShouldReturnEveryProductsInStock()
        {
            var product = new Product("label", 15m, 1);
            this.stock.Add(product);
            var otherProduct = new Product("otherLabel", 15m, 3);
            this.stock.Add(otherProduct);
            List<string> expectedLabelsCollection = new List<string>()
            {
                "someLabel",
                "label",
                "otherLabel"
            };

            List<string> actualLabelsCollection = new List<string>();
            foreach (var prod in this.stock)
            {
                actualLabelsCollection.Add(prod.Label);
            }

            CollectionAssert.AreEqual(expectedLabelsCollection, actualLabelsCollection);
        }

        [Test]
        public void RemoveShouldRemoveTheGivenProduct()
        {
            this.stock.Remove(this.product);

            CollectionAssert.IsEmpty(this.stock);
        }

        [Test]
        public void RemoveShouldReturnTrueWhenRemovedTheGivenProduct()
        {
            Assert.IsTrue(this.stock.Remove(this.product));
        }

        [Test]
        public void RemoveShouldReturnFalseWhenTheGivenProductIsNotPresentInStock()
        {
            var productToRemove = new Product("label", 15m, 1);

            Assert.IsFalse(this.stock.Remove(productToRemove));
        }

        [Test]
        public void RemoveShouldThrowArgumentNullExceptionWhenRemovingNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.stock.Remove(null));
        }
    }
}
using System;
using System.Linq;

using NUnit.Framework;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager storeManager;
        private Product product;

        [SetUp]
        public void Setup()
        {
            this.storeManager = new StoreManager();
            this.product = new Product("product", 1, 15m);
        }

        [Test]
        public void Constructor_ShouldInitializeInnerCollection()
        {
            Assert.IsNotNull(this.storeManager.Products);
        }

        [Test]
        public void Count_ShouldReturnCorrect()
        {
            this.storeManager.AddProduct(this.product);

            Assert.AreEqual(1, this.storeManager.Count);
        }

        [Test]
        public void AddProduct_ShouldThrowArgumentNullExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.storeManager.AddProduct(null));
        }

        [Test]
        public void AddProduct_ShouldThrowArgumentExceptionWhenProductQuantityLessThanOrEqualZero()
        {
            var product = new Product("a", 0, 5m);

            Assert.Throws<ArgumentException>(() => this.storeManager.AddProduct(product));
        }

        [Test]
        public void AddProduct_ShouldAddCorrectProduct()
        {
            this.storeManager.AddProduct(this.product);

            CollectionAssert.Contains(this.storeManager.Products, this.product);
        }

        [Test]
        public void BuyProduct_ShouldThrowArgumentNullExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.storeManager.BuyProduct("a", 5));
        }

        [Test]
        public void BuyProduct_ShouldThrowArgumentExceptionWhenProductQuantityLessThanGivenOne()
        {
            this.storeManager.AddProduct(this.product);

            Assert.Throws<ArgumentException>(() => this.storeManager.BuyProduct("product", 5));
        }

        [Test]
        public void BuyProduct_ShouldReturnFinalPrice()
        {
            var product = new Product("a", 5, 10m);
            this.storeManager.AddProduct(product);

            Assert.AreEqual(30m, this.storeManager.BuyProduct("a", 3));
        }

        [Test]
        public void BuyProduct_ShouldReduceQuantityOfProductInStore()
        {
            var product = new Product("a", 5, 10m);
            this.storeManager.AddProduct(product);

            this.storeManager.BuyProduct("a", 3);
            
            Assert.AreEqual(product.Quantity, this.storeManager.Products.FirstOrDefault(p => p.Name == "a").Quantity);
        }

        [Test]
        public void GetTheMostExpensiveProduct_ShouldReturnTheMostExpensiveProduct()
        {
            this.storeManager.AddProduct(this.product);
            var product1 = new Product("nesto", 3, 100m);
            this.storeManager.AddProduct(product1);
            var product2 = new Product("drugo", 8, 150m);
            this.storeManager.AddProduct(product2);

            var expected = product2;
            var actual = this.storeManager.GetTheMostExpensiveProduct();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetTheMostExpensiveProduct_ShouldReturnNullWhenNoProducts()
        {
            Product expected = null;
            Product actual = this.storeManager.GetTheMostExpensiveProduct();
            Assert.AreEqual(expected, actual);
        }
    }
}
namespace INStock.Tests
{
    using NUnit.Framework;
    // TODO: tests
    // product ctor creates instance with initialized properties correctly - done
    // labels cannot be null, emty or whiteSpace - done
    // label getter work correctly - done
    // label setter work correctly - done
    // price cannot be negative - done
    // price getter work correctly - done
    // price setter work correctly - done
    // quantity cannot be negative - done
    // quantity getter work correctly - done
    // quantity setter work correctly - done
    // CompareTo should compare two products correctly
    [TestFixture]
    public class ProductTests
    {
        private string label;
        private decimal price;
        private int quantity;
        private Product product;

        [SetUp]
        public void Setup()
        {
            this.label = "someLabel";
            this.price = 15m;
            this.quantity = 1;
            this.product = new Product(this.label, this.price, this.quantity);
        }

        [Test]
        public void ConstructorShouldCreateInstanceOfProduct()
        {
            Assert.IsAssignableFrom<Product>(product);
        }

        [Test]
        public void ConstructorShouldInitializePropertiesCorrectly()
        {
            Assert.AreEqual(this.label, this.product.Label, "Label wasn't set correctly!");
            Assert.AreEqual(this.price, this.product.Price, "Price wasn't set correctly!");
            Assert.AreEqual(this.quantity, this.product.Quantity, "Quantity wasn't set correctly!");
        }

        [Test]
        public void LabelShouldThrowArgumentExceptionWhenSettingWithNullEmptyOrWhiteSpace()
        {
            Assert
                .That(
                () => new Product(null, this.price, this.quantity),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Label cannot be null, empty or whiteSpace!"));
        }

        [Test]
        public void LabelShouldReturnTheCorrectLabel()
        {
            string expectedLabel = this.label;

            string actualLabel = this.product.Label;

            Assert.AreEqual(expectedLabel, actualLabel);
        }

        [Test]
        public void LabelShouldSetCorrectValue()
        {
            string expectedLabel = "label";

            this.product = new Product(expectedLabel, this.price, this.quantity);
            string actualLabel = this.product.Label;

            Assert.AreEqual(expectedLabel, actualLabel);
        }

        [Test]
        public void PriceShouldThrowArgumentExceptionWhenSetWithNegative()
        {
            decimal negativePrice = -5m;

            Assert
                .That(
                () => new Product(this.label, negativePrice, this.quantity),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Price cannot be negative!"));
        }

        [Test]
        public void PriceShouldReturnTheCorrectPrice()
        {
            decimal expectedPrice = this.price;

            decimal actualPrice = this.product.Price;

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void PriceShouldSetCorrectValue()
        {
            decimal expectedPrice = this.price;

            this.product = new Product(this.label, expectedPrice, this.quantity);
            decimal actualPrice = this.product.Price;

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void QuantityShouldThrowArgumentExceptionWhenSetToNegative()
        {
            int negativeQuantity = -5;

            Assert
                .That(
                () => new Product(this.label, this.price, negativeQuantity),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Quantity cannot be negative!"));
        }

        [Test]
        public void QuantityShouldReturnTheCorrectQuantity()
        {
            int expectedQuantity = this.quantity;

            decimal actualQuantity = this.product.Quantity;

            Assert.AreEqual(expectedQuantity, actualQuantity);
        }

        [Test]
        public void QuantityShouldSetCorrectValue()
        {
            int expectedQuantity = this.quantity;

            this.product = new Product(this.label, this.price, expectedQuantity);
            decimal actualQuantity = this.product.Quantity;

            Assert.AreEqual(expectedQuantity, actualQuantity);
        }

        [Test]
        public void CompareToShouldReturnZeroWhenComparedToEqualProduct()
        {
            var equalProduct = new Product("otherLabel", 15m, 1);

            int comparisonResult = this.product.CompareTo(equalProduct);

            Assert.AreEqual(0, comparisonResult);
        }

        [Test]
        public void CompareToShouldReturnOneWhenOtherProductHasSamePriceButLessQuantity()
        {
            var lessProduct = new Product("otherLabel", 15m, 0);

            int comparisonResult = this.product.CompareTo(lessProduct);

            Assert.AreEqual(1, comparisonResult);
        }

        [Test]
        public void CompareToShouldReturnNegativeWhenOtherProductHasSamePriceButGreaterQuantity()
        {
            var greaterProduct = new Product("otherLabel", 15m, 10);

            int comparisonResult = this.product.CompareTo(greaterProduct);

            Assert.AreEqual(-1, comparisonResult);
        }

        [Test]
        public void CompareToShouldReturnNegativeWhenOtherProductHasGreaterPrice()
        {
            var greaterProduct = new Product("otherLabel", 20m, 1);

            int comparisonResult = this.product.CompareTo(greaterProduct);
            Assert.AreEqual(-1, comparisonResult);
        }

        [Test]
        public void CompareToShouldReturnOneWhenOtherProductHasLessPrice()
        {
            var lessProduct = new Product("otherLabel", 10m, 1);

            int comparisonResult = this.product.CompareTo(lessProduct);
            Assert.AreEqual(1, comparisonResult);
        }
    }
}
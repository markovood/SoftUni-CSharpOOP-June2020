using System;

using INStock.Contracts;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get
            {
                return this.label;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label cannot be null, empty or whiteSpace!");
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative!");
                }

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            if (this.Price == other.Price)
            {
                if (this.quantity == other.Quantity)
                {
                    return 0;
                }
                else if (this.quantity > other.Quantity)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (this.price > other.Price)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
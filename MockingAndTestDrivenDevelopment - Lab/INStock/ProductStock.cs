using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> stock;

        public ProductStock()
        {
            this.stock = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get
            {
                return this.stock[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.stock[index] = value;
            }
        }

        public int Count => this.stock.Count;

        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product", "Null values cannot be added!");
            }

            if (this.stock.Any(p => p.Label == product.Label))
            {
                throw new InvalidOperationException("Product's label must be unique!");
            }

            this.stock.Add(product);
        }

        public bool Contains(IProduct product)
        {
            if (this.stock.Any(p => p.Label == product.Label))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return this.stock[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            return this.stock.Where(p => p.Price == (decimal)price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.stock.Where(p => p.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            return this.stock
                            .Where(p =>
                                    p.Price >= (decimal)lo &&
                                    p.Price <= (decimal)hi)
                            .OrderByDescending(p => p.Price);
        }

        public IProduct FindByLabel(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException();
            }

            var result = this.stock.Find(p => p.Label == label);

            if (result == null)
            {
                throw new ArgumentException("No such product is in stock!");
            }

            return result;
        }

        public IProduct FindMostExpensiveProduct()
        {
            decimal maxPrice = 0;
            foreach (var product in this.stock)
            {
                if (product.Price > maxPrice)
                {
                    maxPrice = product.Price;
                }
            }

            return this.stock.FirstOrDefault(p => p.Price == maxPrice);
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < this.stock.Count; i++)
            {
                yield return this.stock[i];
            }
        }

        public bool Remove(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            return this.stock.Remove(product);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
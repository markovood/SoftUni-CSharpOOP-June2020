using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyList<Product> Bag { get => this.bag.AsReadOnly(); }

        public bool Buy(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.Money -= product.Cost;
                this.bag.Add(product);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public IReadOnlyList<Topping> Toppings
        {
            get => this.toppings.AsReadOnly();
        }

        public double TotalCalories
        {
            get => this.CalculateCalories();
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }

        private double CalculateCalories()
        {
            double toppingsTotalCalories = GetTotalToppingsCalories(this.toppings);
            return (this.Dough.WeightGR * this.Dough.CaloriesPerGR) + toppingsTotalCalories;
        }

        private double GetTotalToppingsCalories(List<Topping> toppings)
        {
            double calories = 0;
            foreach (var topping in toppings)
            {
                calories += topping.WeightGR * topping.CaloriesPerGR;
            }

            return calories;
        }
    }
}
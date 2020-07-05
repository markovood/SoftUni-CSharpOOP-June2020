using System;

namespace PizzaCalories
{
    public class Topping : Ingredient
    {
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.WeightGR = weight;

            // set up 'modifier' field
            switch (this.toppingType.ToLower())
            {
                case "meat":
                    this.Modifier = 1.2;
                    break;
                case "veggies":
                    this.Modifier = 0.8;
                    break;
                case "cheese":
                    this.Modifier = 1.1;
                    break;
                case "sauce":
                    this.Modifier = 0.9;
                    break;
            }
        }

        private string ToppingType
        {
            set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public override double WeightGR
        {
            get => this.weight;
            protected set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }
    }
}
using System;

namespace PizzaCalories
{
    public class Dough : Ingredient
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.WeightGR = weight;

            // setting 'modifier' field
            switch (this.flourType.ToLower())
            {
                case "white":
                    this.Modifier = 1.5;
                    break;
                case "wholegrain":
                    this.Modifier = 1.0;
                    break;
            }

            // increasing 'modifier' field
            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    this.Modifier *= 0.9;
                    break;
                case "chewy":
                    this.Modifier *= 1.1;
                    break;
                case "homemade":
                    this.Modifier *= 1.0;
                    break;
            }
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public override double WeightGR
        {
            get => this.weight;
            protected set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }
    }
}
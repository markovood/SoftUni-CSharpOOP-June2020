namespace PizzaCalories
{
    public abstract class Ingredient
    {
        protected const double BASE_CALORIES_PER_GRAM = 2.0;

        public abstract double WeightGR { get; protected set; }

        public double CaloriesPerGR
        {
            get => BASE_CALORIES_PER_GRAM * this.Modifier;
        }

        protected double Modifier { get; set; }
    }
}
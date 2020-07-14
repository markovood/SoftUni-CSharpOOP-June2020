using System;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double WEIGHT_INCREASE_PER_FOOD = 0.25;

        public Owl(string name, double weight, double wingSize) :
            base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * WEIGHT_INCREASE_PER_FOOD;
            this.FoodEaten += food.Quantity;
        }
    }
}
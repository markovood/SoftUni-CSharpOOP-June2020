using System;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const double WEIGHT_INCREASE_PER_FOOD = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) :
            base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            if (!(food is Vegetable) &&
                !(food is Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * WEIGHT_INCREASE_PER_FOOD;
            this.FoodEaten += food.Quantity;
        }
    }
}
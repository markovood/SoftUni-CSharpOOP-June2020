using System;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREASE_PER_FOOD = 0.1;

        public Mouse(string name, double weight, string livingRegion) : 
            base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            if (!(food is Vegetable) &&
                !(food is Fruit))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * WEIGHT_INCREASE_PER_FOOD;
            this.FoodEaten += food.Quantity;
        }
    }
}
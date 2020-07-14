using System;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double WEIGHT_INCREASE_PER_FOOD = 0.4;

        public Dog(string name, double weight, string livingRegion) :
            base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
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
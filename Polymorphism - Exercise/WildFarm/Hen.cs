namespace WildFarm
{
    public class Hen : Bird
    {
        private const double WEIGHT_INCREASE_PER_FOOD = 0.35;

        public Hen(string name, double weight, double wingSize) :
            base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * WEIGHT_INCREASE_PER_FOOD;
            this.FoodEaten += food.Quantity;
        }
    }
}
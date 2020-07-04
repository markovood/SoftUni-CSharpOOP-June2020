namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double GRAMS = 250.0;
        private const double CALORIES = 1000.0;
        private const decimal CAKEPRICE = 5m;

        public Cake(string name) :
            base(name, CAKEPRICE, GRAMS, CALORIES)
        {
        }
    }
}

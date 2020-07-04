namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double GRAMS = 22.0;

        public Fish(string name, decimal price) :
            base(name, price, GRAMS)
        {
        }
    }
}

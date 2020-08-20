namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {
        private const double PERFORMANCE = 15d;

        public DesktopComputer(int id, string manufacturer, string model, decimal price) :
            base(id, manufacturer, model, price, PERFORMANCE)
        {
        }
    }
}
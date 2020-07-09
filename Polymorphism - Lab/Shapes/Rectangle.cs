namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height 
        {
            get => this.height;
            private set => this.height = value;
        }

        public double Width 
        {
            get => this.width;
            private set => this.width = value;
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * this.Width + 2 * this.Height;
        }

        public override string Draw()
        {
            return "I am a rectangle.";
        }
    }
}
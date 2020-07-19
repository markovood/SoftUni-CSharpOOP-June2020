namespace Graphic_Editor_After
{
    public class Program
    {
        public static void Main()
        {
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape square = new Square();
            IShape triangle = new Triangle();

            var ge = new GraphicEditor();
            ge.DrawShape(circle);
            ge.DrawShape(rectangle);
            ge.DrawShape(square);
            ge.DrawShape(triangle);
        }
    }
}
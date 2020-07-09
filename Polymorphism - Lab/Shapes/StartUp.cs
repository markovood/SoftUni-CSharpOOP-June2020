using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            var rect = new Rectangle(5d, 6d);
            var circle = new Circle(3d);

            List<Shape> shapes = new List<Shape>() { rect, circle };

            shapes.ForEach(sh =>
            {
                Console.WriteLine(sh.CalculateArea());
                Console.WriteLine(sh.CalculatePerimeter());
                Console.WriteLine(sh.Draw());
            });
        }
    }
}
using System;

namespace Graphic_Editor_After
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}
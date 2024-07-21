using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape, IDrawing
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public override double CalculateArea() => height * width;

        public override double CalculatePerimeter() => 2 * (height + width);
        public override string Draw()
        {
            return $"Drawing {GetType().Name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Area
{
    internal class Rectangle : Shape
    {
        public double Width {  get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height ,string color) : base(color)
        {
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }
    }
}

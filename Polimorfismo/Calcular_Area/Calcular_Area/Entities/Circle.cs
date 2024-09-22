using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Area
{
    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius, string color) : base(color) 
        {
            Radius = radius;
        }


        public override double Area()
        {
            return Math.PI * (Radius * Radius);
        }
    }
}

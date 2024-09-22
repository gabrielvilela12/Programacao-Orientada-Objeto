using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Area
{
    //Classe abstrata por possuir uma função abstrata
    abstract class Shape
    {
        public string Color {  get; set; }

        public Shape(string color)
        {
            Color = color;
        }

        //Função abstrata criada para ser definida 
        public abstract double Area();
    }
}

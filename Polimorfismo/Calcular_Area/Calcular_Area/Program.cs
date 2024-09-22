using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Lista Shape que pode armazenar dados de Subclasses (Circle / Rectangle)
            List<Shape> pobj_Shape = new List<Shape>();

            Console.Write("Enter with number of shapes: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.Clear();
                Console.WriteLine("Shape #{0} data:\n", i + 1);

                Console.Write("Rectangle or Circle (r/c): ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Color: ");
                string color = Console.ReadLine();
                
                //Entra no if se for um Rectangle
                if (ch == 'r')
                {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine());

                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine());

                    pobj_Shape.Add(new Rectangle(width, height, color)); //Adiciona na Lista um novo objeto da classe Rectangle
                }

                //Entra e faz o Circle
                else
                {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    pobj_Shape.Add(new Circle(radius, color)); //Adiciona na Lista um novo objeto da classe Circle
                }
            }

            Console.WriteLine("Shape Areas\n");

            foreach(Shape shape in pobj_Shape)
            {
                if(shape is Rectangle)
                {
                    Console.WriteLine("Color: {0} - Area of the Rectangle: {1}",shape.Color, shape.Area());
                }
                else
                {
                    Console.WriteLine("Color: {0} - Area of the Circle: {1}",shape.Color, shape.Area().ToString("F2"));
                }
            }

            Console.ReadLine();
        }     
    }
}

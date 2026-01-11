using System;
using System.Collections.Generic;

namespace Comparacao_Igualdade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Product> hs_Product = new HashSet<Product>();
            HashSet<Point> hs_Point = new HashSet<Point>();

            hs_Product.Add(new Product("Pão", 100.50));
            hs_Product.Add(new Product("Queijo", 40));

            hs_Point.Add(new Point(1));
            hs_Point.Add(new Point(2));

            Product obj_Product = new Product("Pão", 100.50);
            Point obj_Point = new Point(1);

            Console.WriteLine(hs_Product.Contains(obj_Product));
            Console.WriteLine(hs_Point.Contains(obj_Point));

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Predicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> pobj_products = new List<Product>();

            pobj_products.Add(new Product ( "Tv", 900.00 ));
            pobj_products.Add(new Product ( "Mouse", 50.00 ));
            pobj_products.Add(new Product("Tablet", 350.50));
            pobj_products.Add(new Product ( "HD Case", 80.90 ));

            pobj_products.RemoveAll(ProductTest);
            foreach(Product p in pobj_products)
            {
                Console.WriteLine(p);
            }
            Console.ReadLine();
        }

        public static bool ProductTest(Product p)
        {
            return p.Price >= 100.0;
        }
    }
}

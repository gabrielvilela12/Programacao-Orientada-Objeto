using System;
using System.Collections.Generic;

namespace Action
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> pobj_products = new List<Product>();

            pobj_products.Add(new Product("Tv", 900.0));
            pobj_products.Add(new Product("Mouse", 50.0));
            pobj_products.Add(new Product("Tablet", 350.50));
            pobj_products.Add(new Product("HD Case", 80.90));
     
            pobj_products.ForEach(p => { p.Price += p.Price * 0.1; });       

            foreach (Product obj in pobj_products)
            {
                Console.WriteLine(obj);
            }
            Console.ReadLine();
        }

        static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Func
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
            
            Func<Product, string> func = p => p.Name.ToUpper();
            List<string> List_Names = pobj_products.Select(func).ToList();

            foreach (string name in List_Names)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }

        static
    }
}

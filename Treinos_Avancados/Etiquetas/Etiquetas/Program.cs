using System;
using System.Collections.Generic;

namespace Etiquetas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> pobj_Product = new List<Product>();   

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            Console.Clear();

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Product #{0}", i + 1);
                Console.Write("\nCommon, Used or Imported (c/u/i): ");
                char type = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                if (type == 'u')
                {
                    Console.Write("Manufacture Date(DD/MM/YYYY): "); //Data de fabricação
                    DateTime dateTime = DateTime.Parse(Console.ReadLine());
                    pobj_Product.Add(new UsedProduct(name, price, dateTime));

                }
                else
                {
                    if (type == 'i')
                    {
                        Console.Write("Customs fee: "); //taxa alfandegária
                        double customsFee = double.Parse(Console.ReadLine());

                        pobj_Product.Add(new ImportedProduct(name, price, customsFee));
                    }
                    else
                    {
                        pobj_Product.Add(new Product(name, price));
                    }
                }
            }

            Console.WriteLine("PRICE TAGS");

            foreach(Product prod in pobj_Product)
            {
               Console.WriteLine(prod.PriceTag());
            }
            Console.ReadLine();
        }
    }
}

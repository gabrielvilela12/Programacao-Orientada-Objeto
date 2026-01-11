using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list_Product = new List<Product>();

            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 1};
            Category c2 = new Category() { Id = 2, Name = "Phone", Tier = 2};
            Category c3 = new Category() { Id = 3, Name = "Blocos", Tier = 3 };


            
            list_Product.Add(new Product(1,"Martelo", 325.50, c1));
            list_Product.Add(new Product(5, "Samsung", 45.10, c2));
            
            list_Product.Add(new Product(7, "Terra", 2000.00, c3));
            list_Product.Add(new Product(3, "Pá", 175.00, c1));
            list_Product.Add(new Product(6, "Tijolo", 2405.50, c3));
            list_Product.Add(new Product(4,"Iphone", 95.35, c2));
            list_Product.Add(new Product(2, "Picareta", 250.50, c1));

            #region Where
            var valor1 = list_Product.Where(p => p.Category.Tier == 1);

            Print("Primeiro Id", valor1);

            var valor2 = list_Product.Where(p => p.Price > 250);

            Print("Price > 250 ", valor2);

            var valor3 = list_Product.Where(p => p.Price > 1000).Sum(p => p.Price);

            Console.WriteLine("Valores acima de mil somados \n" + valor3 + "\n");

            var valor4 = list_Product.Where(p => p.Name[0] == 'P');

            Print("Iniciais P ", valor4);

            #endregion

            #region Select
            var valor5 = list_Product.Select(p => p.Name);

            Print("Nomes", valor5);

            var valor6 = list_Product.Select(p => p.Id);

            Print("Ids",valor6);

            var valor7 = list_Product.Select(p => p.Id > 4);

            Print("B", valor7);

            #endregion

            #region Ordenar
            var valor8 = list_Product.OrderBy(p => p.Price);

            Print("Preço crescente", valor8);

            var valor9 = list_Product.OrderByDescending(p => p.Price);

            Print("Preço decrescente", valor9);
            #endregion


            var valor10 = list_Product.Where(p => p.Category.Tier == 1).Take(2);

            Print("Tier 1, 2 primeiros resultados", valor10);

            var valor11 = list_Product.All(p => p.Price > 1000);

            Console.WriteLine("All price > 1000\n" + valor11);
            Console.ReadLine();

        }

        static void Print<T>(string msg, IEnumerable<T> collection)
        {            
            Console.WriteLine(msg);

            foreach (T item in collection)
            {
                Console.WriteLine(item);     
            }
            Console.WriteLine("-------------------------------");

            Console.WriteLine();
        }
       
    }
}

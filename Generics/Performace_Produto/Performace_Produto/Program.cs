using System;
using System.Collections.Generic;

namespace Performace_Produto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> Pobj_Products = new List<Product>();

            try
            {
                Console.Write("Enter N: ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter with name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter with price: ");
                    double price = double.Parse(Console.ReadLine());

                    Product obj_Product = new Product(name, price);
                    Pobj_Products.Add(obj_Product);
                }

                CalculationService obj_CalculationService = new CalculationService();
                Console.WriteLine("O maior número da lista é: " + obj_CalculationService.Max(Pobj_Products));
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

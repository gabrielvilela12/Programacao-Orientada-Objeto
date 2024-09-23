using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento_Estoque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {      
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Amount: ");
                    int amount = int.Parse(Console.ReadLine());

                    Product obj_Product = new Product(name, price, amount);

                    Console.WriteLine("1. Add");
                    Console.WriteLine("2. Remove");
                    Console.Write("Choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    Console.Write("Amount: ");
                    amount = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        obj_Product.AddAmount(amount);
                    }
                    if (choice == 2)
                    {
                        obj_Product.RemoveProduct(amount);
                    }

                    obj_Product.ViewData();
            }
            catch (DomainExceptions error)
            {
                Console.WriteLine(error.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Value inserted must be a number");
            }
            finally
            {
                Console.ReadLine();
            } 
        }
    }
}

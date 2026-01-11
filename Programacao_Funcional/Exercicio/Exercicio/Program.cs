using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> pobj_Products = new List<Product>();
            ProductService obj_Service = new ProductService();

            string Path = @"C:\Users\Gabriel\source\repos\Programacao_Funcional\Exercicio\produto.csv";

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] strings = line.Split(';');

                        if (strings.Length == 2)
                        {
                            string name = strings[0];
                            double.TryParse(strings[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double price); 

                            pobj_Products.Add(new Product(name, price));
                        }
                    }

                    double avarege = obj_Service.GetAvarege(pobj_Products);

                    Console.WriteLine("The avarege is: R$" + avarege.ToString("F2"));

                    string[] names = obj_Service.GetName(pobj_Products);

                    Console.WriteLine("\n Below average products \n");

                    foreach (var p in names)
                    {
                        Console.WriteLine(p);
                    }
                    Console.ReadLine();     
                }        
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

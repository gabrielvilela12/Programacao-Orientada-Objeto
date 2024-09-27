using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.csv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> pobj_Products = new List<Product>();

            //Cria 2 strings com os caminho do arquivo feito, e o arquivo que será gerado com 
            string sourcePath = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Exercicio.csv\Excel\Original.csv";
            string targetPath = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Exercicio.csv\Excel\Copia.csv";


            try
            {
                //Escreve no documento principal as informações abaixo
                using (StreamWriter sw = new StreamWriter(sourcePath))
                {
                    sw.WriteLine("Nome;Preco;Quantidade");
                    sw.WriteLine("TV LED;1290,99;1");
                    sw.WriteLine("Video Game Chair;350,50;3");
                    sw.WriteLine("Iphone X;900;2");
                    sw.WriteLine("Samsung Galaxy 9;850,50;2");
                }

                using (StreamReader sr = new StreamReader(sourcePath))
                {
                    //Enquanto não estiver no fim do programa irá ler os dados e adicionar na Lista
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lines = line.Split(';');

                        if (lines.Length == 3 && double.TryParse(lines[1], out _))
                        {
                            string name = lines[0];
                            double price = double.Parse(lines[1]);
                            int amount = int.Parse(lines[2]);

                            Product obj_Product = new Product(name, price, amount);

                            pobj_Products.Add(obj_Product);
                        }
                    }

                    //Verifica se o documento "Copia" existe, se não cria
                    if (!File.Exists(targetPath))
                    {
                        File.Create(targetPath).Close();
                    }

                    //Escreve no documento "Copia" os dados armazenado na List, exibindo o total de valor
                    using (StreamWriter sw = new StreamWriter(targetPath))
                    {
                        sw.WriteLine("NOME;VALOR TOTAL");
                        foreach (Product obj_Product in pobj_Products)
                        {
                            sw.WriteLine(obj_Product.Name + ";R$" + obj_Product.TotalValue().ToString("F2", CultureInfo.InvariantCulture));
                        }
                    }
                }
            }
            //Caso ocorra erros
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}

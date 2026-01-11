using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenar_Pessoas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            string path = @"C:\Users\Gabriel\source\repos\Interfaces\Ordenar_Pessoas\in.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path)) //Le o arquivo
                {

                    while (!sr.EndOfStream) //Continua enquanto não estiver no final do documento
                    {
                        list.Add(new Employee(sr.ReadLine())); //Adiciona a lista a linha do documento
                    }
                }
                list.Sort(); //Coloca a lista de forma crescente

                foreach (Employee line in list) 
                {
                    Console.WriteLine(line); 
                }
            }
            //CASO DE ERRO
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally 
            {
                Console.ReadLine();
            }
        }
    }
}

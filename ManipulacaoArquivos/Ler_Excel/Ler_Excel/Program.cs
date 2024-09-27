using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Ler_Excel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Produto> pobj_Produto = new List<Produto>();

            //Cria uma string que recebe o caminho do arquivo
            string path = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Ler_Excel\test1.csv";

            try
            {
                using (StreamReader sr = new StreamReader(path)) //Cria a váriavel sr instanciada pelo método StreamReader recebendo como parámetro o caminho do arquivo
                {
                    while (!sr.EndOfStream) //Cria um looping que será repetido até chegar a ultima linha do arquivo
                    {           
                        string line = sr.ReadLine(); //Le a linha do arquivo e adiciona ela na string "line"
                        string[] strings = line.Split(';'); //Cria um array para armazenar substrings divindo usando como parametro de divisão o ";" 

                        if(strings.Length == 3) //usado para escrever as 3 linhas e adicionalas na Lista
                        {
                            string name = strings[0];
                            double price = double.Parse(strings[1], CultureInfo.InvariantCulture);
                            int amount = int.Parse(strings[2]);
                            Produto produto = new Produto(name, price, amount); //Passa os dados para o Objeto

                            pobj_Produto.Add(produto); //Salva o objeto na lista
                        }
                    }

                    foreach(Produto produto in pobj_Produto) //Imprime no console as linhas do arquivo
                    {
                        Console.WriteLine("Nome: {0} - Preço: {1} - Quantidade: {2} - Total: {3}", produto.Name, produto.Price, produto.Amount, produto.TotalValue());
                    }
                }
                Console.ReadLine();
            }
            catch (Exception ex) //Caso o programa crashe informa o erro
            {
                Console.WriteLine("Erro ao ler o arquivo: " + ex.Message);
            }
        }
    }
}

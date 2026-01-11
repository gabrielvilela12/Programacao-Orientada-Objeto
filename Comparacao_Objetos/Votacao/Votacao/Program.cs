using System;
using System.Collections.Generic;
using System.IO;
namespace Votacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>(); //Usado para pegar os candidatos e a quantidade de seus votos
            string path = @"C:\Users\Gabriel\source\repos\Comparacao_Objetos\Votacao\Votos.txt"; //Caminho do arquivo na pasta

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] lines = sr.ReadLine().Split(','); //Cria substrings separados pela virgula
                        string candidate = lines[0];
                        int votos = int.Parse(lines[1]);


                        if (dictionary.ContainsKey(lines[0]))//Caso o usuario existe
                        {
                            dictionary[candidate] += votos; //Adiciona os votos ao candidato passado pela chave
                        }
                        else
                        {
                            dictionary.Add(lines[0], int.Parse(lines[1])); //Cria o candidato
                        }

                        if (lines.Length == 2)
                        {
                            Console.WriteLine("Nome: {0}, votos {1}", lines[0], lines[1]);
                        }
                    }
                    Console.WriteLine("---------------------------------------");
                    foreach(var line in dictionary) //Acessa o diretório e passa os valores
                    {
                        Console.WriteLine("Nome: {0}, Total de votos: {1}",line.Key, line.Value);
                    }
                    Console.WriteLine("---------------------------------------");

                    Console.ReadLine();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }
        }
    }
}

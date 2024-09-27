using System;
using System.Collections.Generic;
using System.IO;


namespace Criar_Excel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string path = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Criar_Excel\arquivo.csv";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Valor1;Valor2;Valor3"); // Adiciona três valores em uma linha em casas diferentes usando como separador ";"
                }
            } catch (IOException)
            {
                Console.WriteLine("O erro tem a ver com um arquivo");
            }
            

        }
    }
}

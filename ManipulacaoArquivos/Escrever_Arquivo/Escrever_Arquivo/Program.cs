using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escrever_Arquivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Escrever_Arquivo\Arquivo1.txt";
            string targetPath = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Escrever_Arquivo\Arquivo2.txt";

            try
            {
                //Adiciona no array o arquivo
                string[] lines = File.ReadAllLines(sourcePath);

                for (int i = 0; i < 10; i++)
                {
                    //Instancia um StreamWriter para permitir o uso da váriavel para escrever no arquivo
                    using (StreamWriter sw = File.AppendText(targetPath))
                    {
                        foreach (string line in lines) //Usado para escrever linha por linha no arquivo
                        {
                            //Adiciona as linhas no arquivo
                            sw.WriteLine((i + 1) + line.ToUpper());
                        }
                    }
                }   
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

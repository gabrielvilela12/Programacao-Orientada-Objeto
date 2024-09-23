using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Caminho do arquivo
            for (int i = 0; i < 10; i++)
            {
                string sourcePath = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Test1\Arquivo1.txt";
                string targetPath = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Test1\Arquivo2.txt";

                try
                {
                    //instancia o arquivo existente e o que será copiado
                    FileInfo obj_FileInfo = new FileInfo(sourcePath);
                    FileInfo obj_copy = new FileInfo(targetPath);

                    //verifica se o arquivo que será copiado ja existe para evitar exceção
                    if (!obj_copy.Exists)
                    {
                        obj_FileInfo.CopyTo(targetPath);
                    }

                    //Cria um array para armazenar linha por linha do arquivo
                    string[] lines = File.ReadAllLines(sourcePath);

                    //Foreach usado para ler cada linha do arquivo
                    foreach (var item in lines)
                    {
                        Console.WriteLine(item);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    Console.ReadLine();
                }
            }
        }
    }
}

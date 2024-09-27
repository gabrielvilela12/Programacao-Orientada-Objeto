using System;
using System.IO;


namespace Listar_Arquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Gabriel\source\repos\ManipulacaoArquivos\Listar_Arquivos\myfolder\file1.txt";

            Console.WriteLine(" DirectorySeparatorChar: " + Path.DirectorySeparatorChar);
            Console.WriteLine(" PathSeparator: " + Path.PathSeparator);
            Console.WriteLine(" GetDirectoryName: " + Path.GetDirectoryName(path));
            Console.WriteLine(" GetFileName: " + Path.GetFileName(path));
            Console.WriteLine(" GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path));
            Console.WriteLine(" GetExtension: " + Path.GetExtension(path));
            Console.WriteLine(" GetFullPath: " + Path.GetFullPath(path));
            Console.WriteLine(" GetTempPath: " + Path.GetTempPath());
            Console.ReadLine();
        }
    }
}

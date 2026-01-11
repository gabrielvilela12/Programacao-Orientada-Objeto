using Course.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registrar_Log
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Client> set = new HashSet<Client>();
            List<Client> pobj_Cliente = new List<Client>();
            string path = @"C:\Users\Gabriel\source\repos\Comparacao_Objetos\Registrar_Log\Clientes.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path)) 
                {
                    while(!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(' ');
                        string name = line[0];

                        //Formata a forma que o DateTime irá ler
                        DateTime dateTime;
                        if (DateTime.TryParseExact(line[1], "dd/MM/yyyyTHH:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out dateTime))
                        {
                            set.Add(new Client(name, dateTime)); //Adiciona o client no HashSet
                            Client client = new Client(name, dateTime); //Adiciona os dados ao objeto
                            pobj_Cliente.Add(client); //Salva o objeto na Lista
                        }
                    }

                    //Exibe todos os logins no arquivo
                    Console.WriteLine("LISTA DE LOGIN\n------------------------------");
                    

                    foreach (Client obj in pobj_Cliente)
                    {
                        Console.WriteLine(obj.ToString());
                    }
                    Console.WriteLine("------------------------------");


                    //Exibe os usuários que já efeturaram login
                    Console.WriteLine("\nUsuários Cadastrados\n------------------------------");
                    


                    foreach (Client client in set)
                    {
                        
                        Console.WriteLine(client.ToString());
                    }
                    Console.WriteLine("------------------------------");

                    //Número de usuarios cadastrados
                    Console.WriteLine("Usuários diferentes: " + set.Count);

                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();

            }
        }
    }
}

using System;

namespace Comparar_Cliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client { Name = "Maria", Email = "lucas@outlook.com" };
            Client client2 = new Client { Name = "Lucas", Email = "lucas@outlook.com" };

            Console.WriteLine(client1.Equals(client2)); //Verifica se são iguais (oq comparar decidido na operação)
            Console.WriteLine(client1 == client2); //Compara um objeto com outro
            Console.WriteLine(client1.GetHashCode());
            Console.WriteLine(client2.GetHashCode());
            Console.ReadLine();
        }
    }
}

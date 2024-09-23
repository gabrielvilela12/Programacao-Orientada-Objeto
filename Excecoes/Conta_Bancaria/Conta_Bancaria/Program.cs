using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Bancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Holder: ");
                string holder = Console.ReadLine();

                Console.Write("Inicial Balance");
                double balance = double.Parse(Console.ReadLine());

                Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine());

                Account acc = new Account(number, holder, balance, withdrawLimit);


                Console.Write("\nEnter amount for withdraw:");
                double amount = double.Parse(Console.ReadLine());

                try
                {
                    acc.Withdraw(amount);
                    Console.WriteLine("New balance: {0:c}", acc.Balance);
                }
                catch (DomainException n)
                {
                    Console.WriteLine(n.Message);
                }
            }  
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class Account
    {
        public int Number { get; private set; }
        public string Holder {  get; private set; }
        public double Balance { get; protected set; }

        public Account() 
        {
        }

        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        //Método PAI
        public virtual void WithDraw(double amount)//WithDraw = saque
        {
            Balance -= amount; //Saldo da conta - quantidade sacada
        } 

        public void Deposit(double amount)
        {
            Balance += amount; //Saldo da conta + quantidade adicionada
        }

        
    }
}

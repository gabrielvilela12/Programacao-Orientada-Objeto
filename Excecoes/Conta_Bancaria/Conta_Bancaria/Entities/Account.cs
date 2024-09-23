using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Bancaria
{
    internal class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {

            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (Balance < amount)
            {
                throw new DomainException("Valor inserido maior que total na conta");
            }
            if (WithdrawLimit < amount)
            {
                throw new DomainException("Saque maior que o limite da conta ");
            }

            Balance -= amount;
        }
    }
}

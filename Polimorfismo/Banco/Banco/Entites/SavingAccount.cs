using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    sealed class SavingAccount : Account
    {
       public double InterestRate { get; set; }

       public SavingAccount()
        {

        }

        public SavingAccount(int number, string holder, double balance, double interestRate) : base(number, holder, balance)
        {
            InterestRate = interestRate;
        }

        public void UpdateBalanced()
        {
            // Calcula o valor dos juros a serem adicionados ao saldo
            // Balance * InterestRate dá o valor dos juros
            // Por exemplo, se Balance é 1000 e InterestRate é 0.05 (5%), 
            //1000 += 1000 * 0.05 
            //1000 += 50
            //1050

            Balance += Balance * InterestRate; 
        }

        //Subclasse
        public override void WithDraw(double amount)
        {
            base.WithDraw(amount);
            Balance -= 2;
        }
    }
}

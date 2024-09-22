using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class BusinessAccount : Account //Herdou de Account e adicionou LoanLimit (LoanLimit = Limite de impréstimo)
    {
        public double LoanLimit { get; set; }

        public BusinessAccount() { }

        //Construtor da subclasse ("base" utilizado aceitar como parametro o "number" "holder" "balance" como propriedades herdadas do Account)
        public BusinessAccount(int number, string holder, double balance, double loanlimit) : base(number, holder, balance) 
        {
            LoanLimit = loanlimit;
        }

        //Método responsável por pegar empréstimo no banco
        public void Loan(double amount) //Loan = Empréstimo 
        {
            if(amount <= LoanLimit) {
                LoanLimit += amount;
            }
           
        }
        
    }
}

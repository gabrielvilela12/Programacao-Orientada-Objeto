using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    internal class Contract
    {
        public int Number {  get; set; }
        public DateTime Date { get; set; }
        public double ContractValue { get; set; }
        public List<Installments> Installments { get; set; }

        public Contract(int number, DateTime date, double contractValue)
        {
            Number = number;
            Date = date;
            ContractValue = contractValue;
            Installments = new List<Installments>();
        }

        public void AddInstallments(Installments installments)
        {
            Installments.Add(installments);
        }
    }
}

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    internal class Installments
    {
        public DateTime DueDate {  get; set; }
        public double Amount { get; set; }

        public Installments(DateTime dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }

        public override string ToString()
        {
            return DueDate.ToString("dd/MM/yyyy") + " - " + Amount.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}

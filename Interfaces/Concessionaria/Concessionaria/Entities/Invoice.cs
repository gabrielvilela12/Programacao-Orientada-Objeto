using System.Globalization;

namespace Concessionaria
{
    internal class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }
        public double TotalPayment => BasicPayment + Tax;
        

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }    

        public override string ToString()
        {
            return "\nBasic payment: " + BasicPayment.ToString("F2", CultureInfo.InvariantCulture) +
                   "\nTax: " + Tax.ToString("F2", CultureInfo.InvariantCulture) +
                   "\nTotal payament: " + TotalPayment.ToString("F2", CultureInfo.InvariantCulture) ;
        }
    }
}

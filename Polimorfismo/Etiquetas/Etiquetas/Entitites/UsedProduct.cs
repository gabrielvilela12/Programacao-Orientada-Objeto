using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etiquetas
{
    internal class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct() 
        {
        }

        public UsedProduct(string name, double price, DateTime manuFactureDate) : base (name, price)
        {
            ManufactureDate = manuFactureDate;
        }

        public override string PriceTag()
        {
            return Name + " (used) $ " + Price.ToString("F2",CultureInfo.InvariantCulture)  + " (Manufacture date: " + ManufactureDate.ToString("dd/MM/yyyy")+ ")";
        }
    }
}

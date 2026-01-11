using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio
{
    public class ProductService
    {
        public double GetAvarege(List<Product> products)
        {
            return products.Average(p => p.Price);
        }

        public string[] GetName(List<Product> products)
        {
            return products.Where(p => p.Price < GetAvarege(products)).OrderByDescending(p => p.Name).Select(p => p.Name).ToArray();          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.csv
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public Product() 
        {
        }

        public Product(string name, double price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public double TotalValue()
        {
            return Price * Amount;
        }
    }
}

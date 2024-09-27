using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ler_Excel
{
    internal class Produto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount {  get; set; }

        public Produto() { }

        public Produto(string name, double price, int amount)
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

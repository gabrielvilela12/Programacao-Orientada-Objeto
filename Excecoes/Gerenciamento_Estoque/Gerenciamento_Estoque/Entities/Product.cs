using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento_Estoque
{
     class Product
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

        public void AddAmount(int amount)
        {
            Amount += amount;
        }

        public void RemoveProduct(int amount)
        { 
            if(amount > Amount)
            {
                throw new DomainExceptions("quantity greater than total in stock");
            }
            Amount -= amount;
        }

        public void ViewData()
        {
            Console.WriteLine("Name: {0} - Price: {1:c} - Amount: {2}",Name, Price, Amount);
        }
    }
}

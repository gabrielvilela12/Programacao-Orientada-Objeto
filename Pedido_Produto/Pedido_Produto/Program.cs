using System;
using System.Collections.Generic;

namespace Pedido_Produto
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criação de alguns produtos
            Product coffee = new Product("Café", 5.00);
            Product sugar = new Product("Açúcar", 2.50);

            // Criação de um cliente
            Client client = new Client("Gabriel Vilela", "gabrielvipeixoto7@gmail.com", new DateTime(2004, 03, 19));

            // Criação de itens de pedido
            OrderItem item1 = new OrderItem(2, coffee.Price, coffee);
            OrderItem item2 = new OrderItem(1, sugar.Price, sugar);

            // Criação de um pedido
            Order order = new Order
            {
                Moment = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                Status = OrderStatus.Pending,
                Client = client
            };

            // Adicionando itens ao pedido
            order.AddItem(item1);
            order.AddItem(item2);

            // Exibindo detalhes do pedido
            Console.WriteLine("Pedido:");
            Console.WriteLine("Cliente: {0}", order.Client.Name);
            Console.WriteLine("Data e Hora: {0}", order.Moment);
            Console.WriteLine("Status: {0}", order.Status);
            Console.WriteLine("Itens do Pedido:");

            foreach (var item in order.Items)
            {
                Console.WriteLine("- {0} x {1} @ {2} cada", item.Quantity, item.Product.Name, item.Price);
            }

            Console.WriteLine("Total: {0:C}", order.Total());

            // Removendo um item e exibindo o total atualizado
            order.Remove(item2);
            Console.WriteLine("\nApós remover o açúcar:");
            Console.WriteLine("Total Atualizado: {0:C}", order.Total());
            Console.ReadLine();
        }
    }
}

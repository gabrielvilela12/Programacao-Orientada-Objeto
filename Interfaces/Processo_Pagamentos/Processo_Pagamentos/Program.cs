using System;

namespace Processo_Pagamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPaymentService paymentService = null;

            Console.WriteLine("1.PayPal");
            Console.WriteLine("2.Stripe");
            Console.WriteLine("3.PagSeguro");

            Console.Write("\nSelect your Payment method: ");
            int choice = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.Write("Digite o valor: ");
            double orderAmount = double.Parse(Console.ReadLine());
            
            //how it will be processed - Como será processado
            switch (choice)
            {       
                case 1:
                    paymentService = new PayPal();
                    break;
                case 2:
                    paymentService = new Stripe();
                    break;
                case 3:
                    paymentService = new PagSeguro();
                    break;
            }

            // Cria o processador de pagamento
            PaymentProcessor obj_Processor = new PaymentProcessor(paymentService);

            // Processa o pedido
            obj_Processor.ProcessOrder(orderAmount);
            Console.ReadLine();
        }
    }
}

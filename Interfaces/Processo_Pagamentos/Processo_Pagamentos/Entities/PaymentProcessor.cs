using System;

namespace Processo_Pagamentos
{
    internal class PaymentProcessor
    {
        private IPaymentService _paymentService;

        // Construtor que recebe o serviço de pagamento
        public PaymentProcessor(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // Método para processar um pagamento
        public void ProcessOrder(double amount)
        {
            // Processa o pagamento e obtém o valor total
            double totalAmount = _paymentService.ProcessPayment(amount);

            // Exibe as informações do pagamento
            Console.WriteLine("Processando pagamento com: {0}", _paymentService.GetServiceName());
            Console.WriteLine("Valor original: {0:c}", amount);
            Console.WriteLine("Valor total com taxas: {0:c}", totalAmount);
        }
    }
}

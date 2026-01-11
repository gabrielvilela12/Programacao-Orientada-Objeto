namespace Processo_Pagamentos
{
    class Stripe : IPaymentService
    {
        public double ProcessPayment(double amount)
        {
            return amount + 2 + (amount * 0.02);
        }

        public string GetServiceName()
        {
            return "Stripe";
        }  
    }
}

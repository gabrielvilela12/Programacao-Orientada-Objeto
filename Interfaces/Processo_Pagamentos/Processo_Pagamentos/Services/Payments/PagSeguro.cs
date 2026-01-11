namespace Processo_Pagamentos
{
    internal class PagSeguro : IPaymentService
    {
        public double ProcessPayment(double amount)
        {
            return amount + 1 + (amount * 0.02);
        }

        public string GetServiceName()
        {
            return "PagSeguro";
        }
    }
}

namespace Processo_Pagamentos
{
     class PayPal : IPaymentService
    {

        public double ProcessPayment(double amount)
        {
            return amount + (amount * 0.03);
        }

        public string GetServiceName() 
        {
            return "PayPal";
        }
    }
}

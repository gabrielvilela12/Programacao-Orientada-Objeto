namespace Processo_Pagamentos
{
    interface IPaymentService
    {
        double ProcessPayment(double amount);
        string GetServiceName();
    }
}

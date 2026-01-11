using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    internal class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract,int months) 
        {
            double basicQuota = contract.ContractValue / months;
            for (int i = 0; i < months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updateQuota + _onlinePaymentService.PaymentFee(updateQuota);
                contract.AddInstallments(new Installments(date,fullQuota));
            }
        }
    }
}

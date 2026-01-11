using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
     class PaypalService : IOnlinePaymentService
    {
        private const double FeePercentage = 0.02;
        private const double MonthInterest = 0.01;

        public double Interest(double amount,int month)
        {
            return  amount * MonthInterest * month;
        }

        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }
    }
}

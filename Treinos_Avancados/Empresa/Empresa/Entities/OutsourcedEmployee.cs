using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    internal class OutsourcedEmployee : Employee
    {
        public double AddicionalCharge { get; set; }

        public OutsourcedEmployee() 
        {
        }

        public OutsourcedEmployee(string name, int hours, double valuePorHours, double addicionalCharge) : base (name, hours, valuePorHours)
        {
            AddicionalCharge = addicionalCharge;
        }

        public override double Payment()
        {          
            return base.Payment() + AddicionalCharge * 1.1;
        }
    }
}

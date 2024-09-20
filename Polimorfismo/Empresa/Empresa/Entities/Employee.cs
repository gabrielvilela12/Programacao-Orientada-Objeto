using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    internal class Employee //Employee = Funcionario
    {
        public string Name {  get; set; }
        public int Hours { get; set; }
        public double ValuePorHours { get; set; }

        public Employee() 
        {
        }

        public Employee(string name, int hours, double valuePorHours)
        {
            Name = name;
            Hours = hours;
            ValuePorHours = valuePorHours;
        }

        public virtual double Payment()
        {
            return Hours * ValuePorHours;
        } 


    }
}

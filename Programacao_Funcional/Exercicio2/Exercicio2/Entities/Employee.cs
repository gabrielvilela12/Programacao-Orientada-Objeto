using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    public class Employee
    {
        public string Name {  get; set; }
        public string Mail { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string mail, double salary) 
        {
            Name = name;
            Mail = mail;
            Salary = salary;
        }
    }
}

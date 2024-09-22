using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> pobj_Employees = new List<Employee>();

            Console.Write("Enter with number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Employee Number #{0} data:", i + 1);

                Console.Write("Outsourced (y/n); ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("Value por hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                if (ch == 'y')
                {
                    Console.Write("Addicional charge: ");
                    double addicionalCharge = double.Parse(Console.ReadLine());

                    //Adiciona o OutsourcedEmployee criado na Lista
                    pobj_Employees.Add(new OutsourcedEmployee(name, hours, valuePerHour, addicionalCharge));
                }
                else
                {
                    //Adiciona o Employee criado na Lista
                    pobj_Employees.Add(new Employee(name, hours, valuePerHour));
                }
            }

            Console.WriteLine("PAYMENTS");

            foreach (Employee obj in pobj_Employees)
            {
                Console.WriteLine("{0} - {1:c}", obj.Name, obj.Payment());
            }
            Console.ReadLine();
        }
    }
}


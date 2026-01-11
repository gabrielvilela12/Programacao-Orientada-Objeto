using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> pobj_Employee = new List<Employee>();
            FuncGeral obj_FuncGeral = new FuncGeral();

            string Path = @"C:\Users\Gabriel\source\repos\Programacao_Funcional\Exercicio2\Funcionary.txt";

            try
            {
                using (StreamReader sr = File.OpenText(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lines = line.Split(',');
                        string name = lines[0];
                        string mail = lines[1];
                        double.TryParse(lines[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double salary);

                        if (lines.Length == 3 && salary > 0)
                        {
                            pobj_Employee.Add(new Employee(name, mail, salary));
                        }
                    }
                }

                double value = obj_FuncGeral.GetDouble("Enter salary: ");

                string[] list_Email = pobj_Employee.Where(p => p.Salary > value).Select(p => p.Mail).OrderBy(mail => mail).ToArray();

                foreach (string mail in list_Email)
                {
                    Console.WriteLine(mail);
                }

                double sum_Salary = pobj_Employee.Where(p => p.Name.StartsWith("M", StringComparison.OrdinalIgnoreCase)).Sum(p => p.Salary);

                Console.WriteLine("Salary sum of names with the first letter 'M': '" + sum_Salary);
                Console.ReadLine();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    internal class FuncGeral
    {
        public double GetDouble(string msg)
        {
            Console.Write(msg);  // Exibe a mensagem passada no parâmetro "msg"
            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Valor inválido");
            }
            return result;
        }
    }
}

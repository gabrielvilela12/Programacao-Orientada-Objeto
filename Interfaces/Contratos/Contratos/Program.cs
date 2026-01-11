using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Entrada de dados do contrato
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine()); // Número do contrato

            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture); // Data do contrato

            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // Valor total do contrato

            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine()); // Número de parcelas

            // Criação do contrato
            Contract myContract = new Contract(contractNumber, contractDate, contractValue);

            // Criação do serviço de pagamento com o serviço Paypal
            ContractService contractService = new ContractService(new PaypalService());

            // Processamento do contrato (geração de parcelas)
            contractService.ProcessContract(myContract, months);

            // Exibição das parcelas geradas
            Console.WriteLine("Installments:");
            foreach (Installments installment in myContract.Installments)
            {
                Console.WriteLine(installment); // Exibe a data e o valor de cada parcela
            }
            Console.ReadLine();
        }
    }
}
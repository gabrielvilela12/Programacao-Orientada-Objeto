using System;

namespace Sistema_Bancário_Simples.Application.Helpers
{
    public class FuncGeral
    {
        public decimal GetDecimal(string msg)
        {
            decimal valor;

            while (true)
            {
                Console.Write(msg);
                string entrada = Console.ReadLine();

                if (decimal.TryParse(entrada, out valor))
                    return valor;

                Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }

        public int GetInt(string msg)
        {
            int valor;

            while (true)
            {
                Console.Write(msg);
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out valor))
                    return valor;

                Console.WriteLine("Número inválido. Tente novamente.");
            }
        }

        public string GetString(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string valor = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(valor))
                    return valor;

                Console.WriteLine("Texto não pode ser vazio. Tente novamente.");
            }
        }
    }
}

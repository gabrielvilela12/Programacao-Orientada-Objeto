using System;

namespace Programacao_Funcional
{
    internal class Program
    {
        public delegate void Calcular(int a, int b);

        static void Main(string[] args)
        {
            OperacaoService operacaoService = new OperacaoService();

            Calcular operacao = operacaoService.Sum;
            operacao += operacaoService.Subtract;

            operacao(3,5);
            Console.ReadLine();
        }
    }
}


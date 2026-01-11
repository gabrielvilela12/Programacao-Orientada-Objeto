using System;

namespace Programacao_Funcional
{
    internal class OperacaoService
    {
        public void Sum(int a, int b)
        {
            Console.WriteLine("A soma é {0}", a + b);
        }

        public void Subtract(int a , int b)
        { 
            Console.WriteLine("A subtração é {0}",a - b); 
        }
    }
}

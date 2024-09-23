using System;

namespace Teste_Try
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Digite o primeiro número: ");
                int nmr1 = int.Parse(Console.ReadLine());

                Console.Write("Digite o segundo número: ");
                int nmr2 = int.Parse(Console.ReadLine());

                int result = nmr1 / nmr2;
                Console.WriteLine("Resultado: {0}", result);
            }
            // Caso o nmr2 seja 0
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Erro! " + e.Message);
            }
            // Caso o dado inserido seja um caractere
            catch (FormatException e)
            {
                Console.WriteLine("Erro! " + e.Message);
            }
            //Executa independente se der erro ou não
            finally
            {
                Console.WriteLine("Programa finalizado. Obrigado por usar o sistema.");
            }

            Console.ReadLine();
        }
    }
}

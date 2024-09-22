using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO
{
    public class Funcionario
    {
        public string Nome;
        public double Salario;

        public void infoFuncionario(List<Funcionario> list_Funcionario)
        {
            for (int i = 0; i < list_Funcionario.Count; i++)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Nome: {0}", list_Funcionario[i].Nome);
                Console.WriteLine("Salário: {0}", list_Funcionario[i].Salario);

            }
        }

        public double Media_Salario(List<Funcionario> list_Funcionario)
        {
            Funcionario obj_Funcionario = new Funcionario();

            double media_Salario = 0;

            for (int i = 0; i < list_Funcionario.Count; i++)
            {
                media_Salario += list_Funcionario[i].Salario;

                if (i + 1 == list_Funcionario.Count)
                {
                    media_Salario /= i + 1;
                }
            }

            return media_Salario;
        }

        public void ExibirDados()
        {
            Console.WriteLine("\nDados do Funcionário");
            Console.WriteLine("Nome: {0}", Nome);
            Console.WriteLine("Salário: {0:C}", Salario);
        }

        public double SalarioFinal(double d_Liquido, double i_Imposto, double d_Aumento)
        {
            double d_Final = 0;
            d_Liquido = Salario - i_Imposto;
            d_Aumento = d_Liquido * (d_Aumento / 100);

            d_Final = d_Liquido + d_Aumento;
            return d_Final;
        }
    }
}

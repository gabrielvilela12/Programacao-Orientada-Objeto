using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Imposto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pessoa> pobj_Pessoas = new List<Pessoa>();
            


            Console.Write("Entre com o número de vezes: ");
            int n = int.Parse(Console.ReadLine());  

            for(int i = 0; i < n; i++)
            {
                Console.Write("Pessoa Fisica ou Pessoa juridica: (f/j): ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Renda anual: ");
                double rendaAnual = double.Parse(Console.ReadLine());


                if(ch == 'f')
                {
                    Console.Write("Total gasto com saúde: ");
                    double gastoSaude = double.Parse(Console.ReadLine());   

                    pobj_Pessoas.Add(new PessoaFisica(nome,rendaAnual,gastoSaude));
                }
                else 
                {
                    Console.Write("Número total de pessoas: ");
                    int totalPessoa = int.Parse(Console.ReadLine());

                    pobj_Pessoas.Add(new PessoaJuridica(nome,rendaAnual,totalPessoa));
                }      
            }


            //Percorrer a lista e exibir na tela as informações passadas
            double impostoTotal = 0; 
            foreach (Pessoa obj in pobj_Pessoas)
            {
                impostoTotal += obj.CalcImposto();
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("Nome: " + obj.Name);
                Console.WriteLine("Renda anual: {0:c}", obj.RendaAnual);
                Console.WriteLine("Imposto: {0:c}", obj.CalcImposto());
                if (obj is PessoaFisica)
                {
                    Console.WriteLine("Renda anual adicionada com o imposto e 50% do gasto com saúde: {0}", obj.CalcImposto() + obj.RendaAnual);
                }
                else
                {
                    Console.WriteLine("Renda anual adicionada com o imposto e taxa da Quantidade de pessoa: {0}", obj.CalcImposto() + obj.RendaAnual);
                }
                Console.WriteLine("\n-------------------------------------");        
            }

            Console.WriteLine("Imposto total: {0}", impostoTotal);
            Console.ReadLine();
        }
    }
}

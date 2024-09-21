using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO
{
    class Estoque
    {
        public string Nome;
        public double Preco;
        public int Qntd;

        public void ExibirDados()
        {
            Console.WriteLine("\nDados do produto");
            Console.WriteLine("Nome: {0}", Nome);
            Console.WriteLine("Preço: {0:C}", Preco);
            Console.WriteLine("Quantidade: {0}", Qntd);
            Console.WriteLine("Valor total do produto: {0:C}", Qntd * Preco);
        }


        public void MudarQntd(int i_Opc, int i_Qntd)
        {
            switch (i_Opc)
            {
                case 1:
                    Qntd += i_Qntd;
                    break;

                case 2:
                    Qntd -= i_Qntd;
                    break;
            }
        }
    }
}

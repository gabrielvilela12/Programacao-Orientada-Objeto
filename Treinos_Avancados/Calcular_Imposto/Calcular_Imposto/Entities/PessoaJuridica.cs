using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Imposto
{
    internal class PessoaJuridica : Pessoa
    {
        public int NumeroFuncionario { get; set; }

        public PessoaJuridica()
        {

        }

        public PessoaJuridica(string name, double rendaAnual, int numeroFuncionario) : base(name, rendaAnual)
        {
            NumeroFuncionario = numeroFuncionario;
        }

        //override usado para herdar a função da classe Pessoa
        public override double CalcImposto()
        {
            double imposto = 0;

            if (NumeroFuncionario > 10)
            {
                imposto = RendaAnual * 14 / 100;
            }
            else
            {
                imposto = RendaAnual * 16 / 100;
            }
            return imposto;
        }
    }
}

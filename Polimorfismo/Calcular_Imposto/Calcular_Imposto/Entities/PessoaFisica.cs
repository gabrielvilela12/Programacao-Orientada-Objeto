using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Imposto
{
    class PessoaFisica : Pessoa
    {
        public double GastoSaude {  get; set; }

        public PessoaFisica()
        {

        }

        public PessoaFisica(string name, double rendaAnual, double gastoSaude) : base( name, rendaAnual)
        {
            GastoSaude = gastoSaude;
        }

        //override usado para herdar a função da classe Pessoa
        public override double CalcImposto()
        {
            double imposto = 0;
            if (RendaAnual < 2000)
            {
               imposto = RendaAnual * 15 / 100;
            }
            if(RendaAnual >= 2000)
            {
               imposto = RendaAnual * 25 / 100;
            }

            if(GastoSaude > 0)
            {
                imposto += (GastoSaude / 2);
            }

            return imposto;
        }
    }
}

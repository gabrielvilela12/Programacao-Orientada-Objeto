using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Imposto
{
    //abstract utilizado para bloquear a classe de ser chamada em outras páginas
    abstract class Pessoa
    {
        public string Name {  get; set; }
        public double RendaAnual {  get; set; }

        public Pessoa() { }

        public Pessoa(string name, double rendaAnual) 
        {
            Name = name;
            RendaAnual = rendaAnual; 
        }

        public abstract double CalcImposto();
    }
}

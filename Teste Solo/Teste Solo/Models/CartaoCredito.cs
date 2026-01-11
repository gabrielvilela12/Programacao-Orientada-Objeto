using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_Solo.Model
{
    public class CartaoCredito
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public string NomeTitular { get; set; }

        public int CodigoSeguranca { get; set; }

        public decimal LimiteCredito { get; set; }
    }

}

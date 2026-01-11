using Controle_de_Contatos.Models;

namespace Controle_de_Contatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();

        ContatoModel BuscarPeloId(int id);

        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);



    }
}

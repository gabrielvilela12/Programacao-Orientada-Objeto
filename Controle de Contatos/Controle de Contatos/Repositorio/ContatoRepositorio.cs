using Controle_de_Contatos.Data;
using Controle_de_Contatos.Models;

namespace Controle_de_Contatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly DbConnectionContext _connection;

        public ContatoRepositorio(DbConnectionContext DbConnection)
        {
            _connection = DbConnection;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _connection.Contatos.ToList();
        }
        public ContatoModel BuscarPeloId(int id)
        {
            return _connection.Contatos.FirstOrDefault(x => x.Id == id);
        }




        public ContatoModel Adicionar(ContatoModel contato)
        {
            _connection.Contatos.Add(contato);
            _connection.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPeloId(contato.Id);

            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato");

            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _connection.Contatos.Update(contatoDB);
            _connection.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = BuscarPeloId(id);

            if (contatoDB == null) throw new Exception("Houve um erro para deletar o contato");

            _connection.Remove(contatoDB);
            _connection.SaveChanges();
            return true;
        }
    }
}

using Controle_de_Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Contatos.Data
{
    public class DbConnectionContext : DbContext
    {
        public DbConnectionContext(DbContextOptions<DbConnectionContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}

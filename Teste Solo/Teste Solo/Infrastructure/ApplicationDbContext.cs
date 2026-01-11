using Microsoft.EntityFrameworkCore;
using Teste_Solo.Model;

namespace Teste_Solo.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CartaoCredito> CartaoCredito { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartaoCreditoConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}

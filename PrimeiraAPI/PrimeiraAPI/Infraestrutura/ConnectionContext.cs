using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Model;

namespace PrimeiraAPI.Infraestrutura

{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql (
            "Server=localhost;" +
            "Port=5432;Database=Teste;" +
            "User Id=postgres;" +
            "Password=Itneverends1020@;");       
    }
}

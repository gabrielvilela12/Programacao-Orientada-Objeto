using Microsoft.EntityFrameworkCore;
using Sistema_Bancário_Simples.Domain.Data.Connection;
using Sistema_Bancário_Simples.Domain.Entities;

namespace Sistema_Bancário_Simples
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(DbConnection.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Balance).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserLogedId).IsRequired();
                entity.Property(e => e.UserTransferenceId).IsRequired();
                entity.Property(e => e.transferAmount).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.PaymentDate).IsRequired();
                entity.HasOne<User>().WithMany().HasForeignKey(e => e.UserLogedId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
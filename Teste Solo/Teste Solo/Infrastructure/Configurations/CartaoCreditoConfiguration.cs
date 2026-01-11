using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste_Solo.Model;

public class CartaoCreditoConfiguration : IEntityTypeConfiguration<CartaoCredito>
{
    public void Configure(EntityTypeBuilder<CartaoCredito> builder)
    {
        builder.ToTable("cartaocredito");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("id").IsRequired();
        builder.Property(c => c.Numero).HasColumnName("numero").IsRequired();
        builder.Property(c => c.NomeTitular).HasColumnName("nometitular").IsRequired();
        builder.Property(c => c.CodigoSeguranca).HasColumnName("codigoseguranca").IsRequired();
        builder.Property(c => c.LimiteCredito).HasColumnName("limitecredito").IsRequired();
    }
}
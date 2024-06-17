using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(Cliente));

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Endereco)
                .HasColumnName("Email")
                .IsRequired();
            });

            builder.OwnsOne(x => x.Cpf, cpf =>
            {
                cpf.Property(x => x.Documento)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();
            });

            builder.HasMany(c => c.Investimentos)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId);
        }
    }
}

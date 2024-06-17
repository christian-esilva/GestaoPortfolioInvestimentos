using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Enums;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Configurations
{
    internal class InvestimentoConfiguration : IEntityTypeConfiguration<Investimento>
    {
        public void Configure(EntityTypeBuilder<Investimento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(Investimento));

            builder.HasOne(x => x.ProdutoInvestimento)
                .WithMany()
                .HasForeignKey(x => x.ProdutoInvestimentoId)
                .HasConstraintName($"FK_{nameof(ProdutoInvestimento)}ProdutoInvestimentoId")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.StatusInvestimento)
                .HasConversion(new ValueConverter<StatusInvestimento, string>(x => x.ToString(),
                x => (StatusInvestimento)Enum.Parse(typeof(StatusInvestimento), x)));
        }
    }
}

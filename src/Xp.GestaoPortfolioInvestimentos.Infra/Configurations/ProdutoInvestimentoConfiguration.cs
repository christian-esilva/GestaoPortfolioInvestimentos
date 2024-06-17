using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Enums;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Configurations
{
    public class ProdutoInvestimentoConfiguration : IEntityTypeConfiguration<ProdutoInvestimento>
    {
        public void Configure(EntityTypeBuilder<ProdutoInvestimento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(ProdutoInvestimento));

            builder.Property(x => x.TipoProdutoInvestimento)
                .HasConversion(new ValueConverter<ETipoProdutoInvestimento, string>(x => x.ToString(),
                x => (ETipoProdutoInvestimento)Enum.Parse(typeof(ETipoProdutoInvestimento), x)));
        }
    }
}

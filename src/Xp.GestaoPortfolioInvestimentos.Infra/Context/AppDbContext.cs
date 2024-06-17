using Microsoft.EntityFrameworkCore;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {       
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Investimento> Investimentos { get; set; }
    public DbSet<ProdutoInvestimento> ProdutosInvestimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;

public interface IProdutoInvestimentoRepositorio
{
    Task<ProdutoInvestimento> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<ProdutoInvestimento>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProdutoInvestimento> AddAsync(ProdutoInvestimento produtoInvestimento, CancellationToken cancellationToken);
    void UpdateAsync(ProdutoInvestimento produtoInvestimento);
    Task<ProdutoInvestimento> DeleteAsync(Guid id, CancellationToken cancellationToken);
}

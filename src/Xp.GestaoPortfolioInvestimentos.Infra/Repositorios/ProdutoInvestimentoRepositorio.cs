using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Repositorios;

public class ProdutoInvestimentoRepositorio : IProdutoInvestimentoRepositorio
{
    public Task<ProdutoInvestimento> AddAsync(ProdutoInvestimento produtoInvestimento, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProdutoInvestimento> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProdutoInvestimento>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProdutoInvestimento> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(ProdutoInvestimento produtoInvestimento)
    {
        throw new NotImplementedException();
    }
}

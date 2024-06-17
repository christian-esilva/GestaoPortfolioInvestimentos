using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Repositorios;

public class InvestimentoRepositorio : IInvestimentoRepositorio
{
    public Task<Investimento> Compra(Guid id, decimal valor, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Investimento>> ExtratoPorProduto(Guid produtoInvestimentoId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Investimento>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Investimento> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Investimento> Venda(Guid id, decimal valor, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

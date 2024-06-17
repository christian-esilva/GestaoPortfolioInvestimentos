using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;

public interface IInvestimentoRepositorio
{
    Task<Investimento> GetByIdAsync(Guid id);
    Task<Investimento> Venda(Guid id, decimal valor, CancellationToken cancellationToken);
    Task<Investimento> Compra(Guid id, decimal valor, CancellationToken cancellationToken);
    Task<IEnumerable<Investimento>> GetAllAsync(CancellationToken cancellationToken);
    Task<IEnumerable<Investimento>> ExtratoPorProduto(Guid produtoInvestimentoId, CancellationToken cancellationToken);
}

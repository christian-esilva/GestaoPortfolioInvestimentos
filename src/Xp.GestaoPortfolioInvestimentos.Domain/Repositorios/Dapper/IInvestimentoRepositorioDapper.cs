using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper
{
    public interface IInvestimentoRepositorioDapper
    {
        Task<Investimento> ObterPorId(Guid id);
        Task<Investimento> ObterPorProdutoInvestimentoECliente(Guid produtoInvestimentoId, Guid clienteId);
    }
}

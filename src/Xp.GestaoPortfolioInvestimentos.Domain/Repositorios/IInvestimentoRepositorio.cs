using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;

public interface IInvestimentoRepositorio
{
    Task<Investimento> Venda(Investimento investimento);
    Task<Investimento> Compra(Investimento investimento);
}

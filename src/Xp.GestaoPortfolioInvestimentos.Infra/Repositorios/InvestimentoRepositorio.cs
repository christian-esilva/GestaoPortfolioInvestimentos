using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Infra.Context;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Repositorios;

public class InvestimentoRepositorio : IInvestimentoRepositorio
{
    protected readonly AppDbContext _appDbContext;

    public InvestimentoRepositorio(AppDbContext db)
    {
        _appDbContext = db;
    }

    public async Task<Investimento> Compra(Investimento investimento)
    {
        if (investimento == null)
            throw new ArgumentNullException(nameof(investimento));

        await _appDbContext.Investimentos.AddAsync(investimento);

        return investimento;
    }

    public async Task<Investimento> Venda(Investimento investimento)
    {
        if (investimento == null)
            throw new ArgumentNullException(nameof(investimento));

        _appDbContext.Investimentos.Update(investimento);

        return investimento;
    }
}

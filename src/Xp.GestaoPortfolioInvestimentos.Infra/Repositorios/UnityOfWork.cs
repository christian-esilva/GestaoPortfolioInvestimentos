using Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes;
using Xp.GestaoPortfolioInvestimentos.Infra.Context;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Repositorios;

public sealed class UnityOfWork : IUnityOfWork, IDisposable
{
    private readonly AppDbContext _context;

    public UnityOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

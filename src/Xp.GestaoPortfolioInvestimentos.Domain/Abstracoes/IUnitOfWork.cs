namespace Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken);
    }
}

namespace Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes
{
    public interface IUnityOfWork : IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken);
    }
}

namespace Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

public abstract class Entidade
{
    public Guid Id { get; protected set; }

    protected Entidade()
    {
        Id = Guid.NewGuid();
    }
}

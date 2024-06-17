namespace Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

public abstract class Entidade
{
    public Guid Id { get; private set; }

    protected Entidade()
    {
        Id = Guid.NewGuid();
    }
}

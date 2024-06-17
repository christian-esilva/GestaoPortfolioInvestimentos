namespace Xp.GestaoPortfolioInvestimentos.Shared.Common;

public readonly struct ValueFailureDetail
{
    public string Description { get; }

    public ValueFailureDetail(string description)
    {
        Description = description;
    }

    public static implicit operator ValueFailureDetail(string description)
    {
        return new ValueFailureDetail(description);
    }
}

namespace Xp.GestaoPortfolioInvestimentos.Application.Exceptions;

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException()
        : base($"Saldo insuficiente para compra do investimento") { }
}

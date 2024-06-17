namespace Xp.GestaoPortfolioInvestimentos.Application.Exceptions;

public class InvestimentoNaoEncontradoException : Exception
{
    public InvestimentoNaoEncontradoException()
        : base($"Investimento não encontrado.") { }
}

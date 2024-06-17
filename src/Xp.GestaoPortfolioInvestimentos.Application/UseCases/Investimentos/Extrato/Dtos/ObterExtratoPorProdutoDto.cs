namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Extrato.Dtos;

public record ObterExtratoPorProdutoDto
{
    public Guid ProdutoInvestimentoId { get; init; }
    public Guid ClienteId { get; init; }
}

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Extrato.Dtos;

public sealed record ExtratoRecuperadoDto
{
    public string NomeProduto { get; init; }
    public decimal Valor { get; init; }
    public string Status { get; init; }
}

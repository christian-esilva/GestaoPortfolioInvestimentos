using MediatR;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Vender.Dtos;

public sealed record VenderInvestimentoDto : IRequest<InvestimentoVendidoDto>
{
    public Guid InvestimentoId { get; init; }
    public Guid ClienteId { get; init; }
    public Guid ProdutoInvestimentoId { get; init; }
    public decimal ValorVenda { get; init; }
}

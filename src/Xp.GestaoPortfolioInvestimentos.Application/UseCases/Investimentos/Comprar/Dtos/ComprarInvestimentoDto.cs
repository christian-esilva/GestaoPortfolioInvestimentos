using MediatR;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Comprar.Dtos;

public sealed record ComprarInvestimentoDto : IRequest<InvestimentoCompradoDto>
{
    public Guid ClienteId { get; init; }
    public Guid ProdutoInvestimentoId { get; init; }
    public decimal ValorCompra { get; init; }
}

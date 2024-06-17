using MediatR;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.ObterClientes.Dtos;

public sealed record ObterClientesDto : IRequest<List<ClientesRecuperadosDto>>
{
}

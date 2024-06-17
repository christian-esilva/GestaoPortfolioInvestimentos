using MediatR;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Shared.Dtos;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Dtos;

public sealed record AdicionarClienteDto : ClienteDto, IRequest<ClienteAdicionadoDto>
{
    public AdicionarClienteDto(ClienteDto original) : base(original)
    {
    }
}

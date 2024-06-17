using MediatR;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Dtos;

public sealed record AdicionarClienteDto : IRequest<ClienteAdicionadoDto>
{
    public string Nome { get; init; }
    public string Email { get; init; }
    public string Cpf { get; init; }
    public decimal Saldo { get; init; }
}

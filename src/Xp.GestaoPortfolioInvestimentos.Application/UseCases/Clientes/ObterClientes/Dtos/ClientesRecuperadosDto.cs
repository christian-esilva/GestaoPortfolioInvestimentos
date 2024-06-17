using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.ObterClientes.Dtos;

public sealed record ClientesRecuperadosDto
{
    public Guid Id { get; init; }
    public string Nome { get; init; }
    public string Email { get; init; }
    public string Cpf { get; init; }

    public static implicit operator ClientesRecuperadosDto (Cliente cliente)
    {
        return new ClientesRecuperadosDto
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Cpf = cliente.Cpf.Documento,
            Email = cliente.Email.Endereco
        };
    }
}

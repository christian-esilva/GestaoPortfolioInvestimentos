namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Shared.Dtos;

public record ClienteDto
{
    public ClienteDto(string nome, string email, string cpf)
    {
        Nome = nome;
        Email = email;
        Cpf = cpf;
    }

    public string Nome { get; init; }
    public string Email { get; init; }
    public string Cpf { get; init; }
}

using Xp.GestaoPortfolioInvestimentos.Domain.Validation;
using Xp.GestaoPortfolioInvestimentos.Domain.ValueObjects;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

public sealed class Cliente : Entidade
{
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public Cpf Cpf { get; private set; }
    public IList<Investimento> Investimentos { get; private set; }

    private Cliente()
    {
        Investimentos = [];
    }

    public Cliente(string nome, string email, string cpf)
    {
        Validar(nome, email, cpf);
    }

    private void Validar(string nome, string email, string cpf)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(nome),
            "Nome inválido");

        Email = new Email(email);
        Cpf = new Cpf(email);
        Nome = nome;
    }
}

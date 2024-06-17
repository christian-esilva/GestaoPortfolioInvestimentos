using Xp.GestaoPortfolioInvestimentos.Domain.Enums;
using Xp.GestaoPortfolioInvestimentos.Domain.Validation;
using Xp.GestaoPortfolioInvestimentos.Domain.ValueObjects;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

public sealed class Cliente : Entidade
{
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public Cpf Cpf { get; private set; }
    public decimal Saldo { get; private set; }
    public IList<Investimento> Investimentos { get; private set; }

    private Cliente()
    {
        Investimentos = [];
    }

    public Cliente(string nome, string email, string cpf)
    {
        Validar(nome, email, cpf);
    }
    public Cliente(Guid id, string nome, string email, string cpf)
    {
        Validar(nome, email, cpf);
        Id = id;
    }

    public void AtualizarSaldo(decimal valor, EAcaoSaldo acao)
    {
        switch (acao)
        {
            case EAcaoSaldo.Debitar:
                if (Saldo >= valor)
                    Saldo -= valor;
                else
                    throw new DomainValidation("Saldo insuficiente para débito.");
                break;

            case EAcaoSaldo.Creditar:
                Saldo += valor;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(acao), acao, null);
        }
    }

    public decimal ObterSaldo()
    {
        return Saldo;
    }

    private void Validar(string nome, string email, string cpf)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(nome), "Nome inválido");
        DomainValidation.When(!Email.EhEmailValido(email), "E-mail inválido");
        DomainValidation.When(!Cpf.EhCpfValido(cpf), "CPF inválido");

        Nome = nome;
        Email = new Email(email);
        Cpf = new Cpf(cpf);
    }
}

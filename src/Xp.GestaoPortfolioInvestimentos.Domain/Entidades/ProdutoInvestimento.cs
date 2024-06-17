using Xp.GestaoPortfolioInvestimentos.Domain.Enums;
using Xp.GestaoPortfolioInvestimentos.Domain.Validation;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

public sealed class ProdutoInvestimento : Entidade
{
    public string Nome { get; private set; }
    public ETipoProdutoInvestimento TipoProdutoInvestimento { get; private set; }
    public decimal Preco { get; private set; }
    public DateTime DataVencimento { get; private set; }

    public ProdutoInvestimento(string nome, ETipoProdutoInvestimento tipoProdutoInvestimento, decimal preco, DateTime dataVencimento)
    {
        Validar(nome, tipoProdutoInvestimento, preco, dataVencimento);
    }

    private void Validar(string nome, ETipoProdutoInvestimento tipoProdutoInvestimento, decimal preco, DateTime dataVencimento)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(nome),
            "Nome inválido");

        DomainValidation.When(preco < 0,
            "Preço deve ser maior que zero");

        DomainValidation.When(dataVencimento < DateTime.Today,
            "Data de vencimento deve ser maior que a data atual");

        Nome = nome;
        TipoProdutoInvestimento = tipoProdutoInvestimento;
        Preco = preco;
        DataVencimento = dataVencimento;
    }
}

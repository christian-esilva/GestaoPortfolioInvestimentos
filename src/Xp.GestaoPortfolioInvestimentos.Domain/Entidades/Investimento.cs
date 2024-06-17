using Xp.GestaoPortfolioInvestimentos.Domain.Enums;
using Xp.GestaoPortfolioInvestimentos.Domain.Validation;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

public sealed class Investimento : Entidade
{
    public Guid ClienteId { get; private set; }
    public Guid ProdutoInvestimentoId { get; private set; }
    public decimal ValorCompra { get; private set; }
    public DateTime DataCompra { get; private set; }
    public StatusInvestimento StatusInvestimento { get; private set; }
    public Cliente Cliente { get; private set; }
    public ProdutoInvestimento ProdutoInvestimento { get; private set; }

    private Investimento() { }

    public Investimento(Guid clienteId, Guid produtoInvestimentoId, decimal valorCompra)
    {
        Validar(clienteId, produtoInvestimentoId, valorCompra);
        StatusInvestimento = StatusInvestimento.Ativo;
        DataCompra = DateTime.Now;
    }

    private static void Validar(Guid clienteId, Guid produtoInvestimentoId, decimal valorCompra)
    {
        DomainValidation.When(clienteId == Guid.Empty, "Id do cliente é inválido");
        DomainValidation.When(produtoInvestimentoId == Guid.Empty, "Id do Produto é inválido");
        DomainValidation.When(valorCompra < 0, "Valor de compra é inválido");
    }
}

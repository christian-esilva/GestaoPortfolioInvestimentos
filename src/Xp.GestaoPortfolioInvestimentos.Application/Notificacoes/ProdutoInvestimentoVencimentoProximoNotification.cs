using MediatR;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Application.Notificacoes;

public class ProdutoInvestimentoVencimentoProximoNotification : INotification
{
    public ProdutoInvestimento ProdutoInvestimento { get; }

    public ProdutoInvestimentoVencimentoProximoNotification(ProdutoInvestimento produtoInvestimento)
    {
        ProdutoInvestimento = produtoInvestimento;
    }
}

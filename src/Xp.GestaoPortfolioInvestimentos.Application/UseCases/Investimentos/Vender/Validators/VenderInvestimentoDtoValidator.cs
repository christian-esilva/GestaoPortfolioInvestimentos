using FluentValidation;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Vender.Dtos;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Vender.Validators;

public class VenderInvestimentoDtoValidator : AbstractValidator<VenderInvestimentoDto>
{
    public VenderInvestimentoDtoValidator()
    {
        RuleFor(x => x.InvestimentoId).NotEmpty().WithMessage("Id do investimento obrigatório");
        RuleFor(x => x.ProdutoInvestimentoId).NotEmpty().WithMessage("Id do Produto obrigatório");
        RuleFor(x => x.ClienteId).NotEmpty().WithMessage("Id do cliente obrigatório");
        RuleFor(x => x.ValorVenda).NotEmpty().WithMessage("Valor da venda obrigatório");
    }
}

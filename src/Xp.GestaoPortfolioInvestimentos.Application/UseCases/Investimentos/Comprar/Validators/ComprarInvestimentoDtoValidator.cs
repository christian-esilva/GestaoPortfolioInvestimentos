using FluentValidation;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Comprar.Dtos;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Comprar.Validators
{
    public class ComprarInvestimentoDtoValidator : AbstractValidator<ComprarInvestimentoDto>
    {
        public ComprarInvestimentoDtoValidator()
        {
            RuleFor(x => x.ProdutoInvestimentoId).NotEmpty().WithMessage("Id do Produto obrigatório");
            RuleFor(x => x.ClienteId).NotEmpty().WithMessage("Id do cliente obrigatório");
            RuleFor(x => x.ValorCompra).NotEmpty().WithMessage("Valor da compra obrigatório");
        }
    }
}

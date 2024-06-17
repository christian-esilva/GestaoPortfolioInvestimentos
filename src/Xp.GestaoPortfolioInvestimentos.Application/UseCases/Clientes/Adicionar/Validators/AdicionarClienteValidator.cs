using FluentValidation;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Dtos;
using Xp.GestaoPortfolioInvestimentos.Domain.ValueObjects;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Validators
{
    public class AdicionarClienteValidator : AbstractValidator<AdicionarClienteDto>
    {
        public AdicionarClienteValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("Cpf obrigatório")
                .Length(11).WithMessage("Cpf deve ter exatamente 11 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email obrigatório");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");
        }
    }
}

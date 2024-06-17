using FluentValidation;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Dtos;
using Xp.GestaoPortfolioInvestimentos.Domain.ValueObjects;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Validators
{
    internal class AdicionarClienteValidator : AbstractValidator<AdicionarClienteDto>
    {
        public AdicionarClienteValidator()
        {
            RuleFor(x => x.Cpf)
                .Must(Cpf.EhCpfValido)
                .WithMessage("Cpf inválido");

            RuleFor(x => x.Email)
                .Must(Email.EhEmailValido)
                .WithMessage("Email inválido");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");
        }
    }
}

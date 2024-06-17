using FluentValidation;
using MediatR;
using Xp.GestaoPortfolioInvestimentos.Application.Exceptions;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Comprar.Dtos;
using Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Enums;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Comprar;

public sealed class ComprarInvestimentoHandler : IRequestHandler<ComprarInvestimentoDto, InvestimentoCompradoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInvestimentoRepositorio _investimentoRepositorio;
    private readonly IInvestimentoRepositorioDapper _investimentoRepositorioDapper;
    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly IClienteRepositorioDapper _clienteRepositorioDapper;
    private readonly IValidator<ComprarInvestimentoDto> _validator;

    public ComprarInvestimentoHandler(
        IUnitOfWork unitOfWork,
        IInvestimentoRepositorio investimentoRepositorio,
        IInvestimentoRepositorioDapper investimentoRepositorioDapper,
        IClienteRepositorio clienteRepositorio,
        IClienteRepositorioDapper clienteRepositorioDapper,
        IValidator<ComprarInvestimentoDto> validator)
    {
        _unitOfWork = unitOfWork;
        _investimentoRepositorio = investimentoRepositorio;
        _investimentoRepositorioDapper = investimentoRepositorioDapper;
        _clienteRepositorio = clienteRepositorio;
        _clienteRepositorioDapper = clienteRepositorioDapper;
        _validator = validator;
    }

    public async Task<InvestimentoCompradoDto> Handle(ComprarInvestimentoDto request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        var cliente = await _clienteRepositorioDapper.GetByIdAsync(request.ClienteId);

        if (cliente.ObterSaldo() < request.ValorCompra)
            throw new SaldoInsuficienteException();

        var investimento = new Investimento(request.ClienteId, request.ProdutoInvestimentoId, request.ValorCompra);

        cliente.AtualizarSaldo(investimento.ValorCompra, EAcaoSaldo.Debitar);

        _clienteRepositorio.UpdateAsync(cliente);
        await _investimentoRepositorio.Compra(investimento);

        _unitOfWork.CommitAsync(cancellationToken);

        return new InvestimentoCompradoDto { InvestimentoId = investimento.Id };
    }
}

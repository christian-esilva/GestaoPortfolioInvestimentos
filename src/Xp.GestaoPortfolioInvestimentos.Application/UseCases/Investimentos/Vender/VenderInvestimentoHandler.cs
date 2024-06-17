using FluentValidation;
using Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes;
using Xp.GestaoPortfolioInvestimentos.Domain.Enums;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Vender.Dtos;
using MediatR;
using Xp.GestaoPortfolioInvestimentos.Application.Exceptions;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Vender;

public class VenderInvestimentoHandler : IRequestHandler<VenderInvestimentoDto, InvestimentoVendidoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInvestimentoRepositorio _investimentoRepositorio;
    private readonly IInvestimentoRepositorioDapper _investimentoRepositorioDapper;
    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly IClienteRepositorioDapper _clienteRepositorioDapper;
    private readonly IValidator<VenderInvestimentoDto> _validator;

    public VenderInvestimentoHandler(
        IUnitOfWork unitOfWork,
        IInvestimentoRepositorio investimentoRepositorio,
        IInvestimentoRepositorioDapper investimentoRepositorioDapper,
        IClienteRepositorio clienteRepositorio,
        IClienteRepositorioDapper clienteRepositorioDapper,
        IValidator<VenderInvestimentoDto> validator)
    {
        _unitOfWork = unitOfWork;
        _investimentoRepositorio = investimentoRepositorio;
        _investimentoRepositorioDapper = investimentoRepositorioDapper;
        _clienteRepositorio = clienteRepositorio;
        _clienteRepositorioDapper = clienteRepositorioDapper;
        _validator = validator;
    }

    public async Task<InvestimentoVendidoDto> Handle(VenderInvestimentoDto request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        var cliente = await _clienteRepositorioDapper.GetByIdAsync(request.ClienteId);
        var investimento = await _investimentoRepositorioDapper.ObterPorId(request.InvestimentoId);

        if (investimento == null || investimento.ClienteId != request.ClienteId)
            throw new InvestimentoNaoEncontradoException();

        cliente.AtualizarSaldo(request.ValorVenda, EAcaoSaldo.Creditar);

        _clienteRepositorio.UpdateAsync(cliente);
        await _investimentoRepositorio.Venda(investimento);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new InvestimentoVendidoDto { InvestimentoId = investimento.Id };
    }
}

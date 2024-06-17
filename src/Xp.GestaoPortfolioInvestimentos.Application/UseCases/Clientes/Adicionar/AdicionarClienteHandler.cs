using FluentValidation;
using MediatR;
using Xp.GestaoPortfolioInvestimentos.Application.Exceptions;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Dtos;
using Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar;

public sealed class AdicionarClienteHandler : IRequestHandler<AdicionarClienteDto, ClienteAdicionadoDto>
{
    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly IClienteRepositorioDapper _clienteRepositorioDapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<AdicionarClienteDto> _validator;

    public AdicionarClienteHandler(
        IClienteRepositorio clienteRepositorio, 
        IUnitOfWork unitOfWork, 
        IValidator<AdicionarClienteDto> validator, 
        IClienteRepositorioDapper clienteRepositorioDapper)
    {
        _clienteRepositorio = clienteRepositorio;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _clienteRepositorioDapper = clienteRepositorioDapper;
    }

    public async Task<ClienteAdicionadoDto> Handle(AdicionarClienteDto request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        var cliente = await _clienteRepositorioDapper.GetByCpfAsync(request.Cpf);
        if (cliente is null)
            throw new ClienteExistenteException();

        var novoCliente = new Cliente(request.Nome, request.Email, request.Cpf);

        await _clienteRepositorio.AddAsync(novoCliente);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ClienteAdicionadoDto { Id = novoCliente.Id };
    }
}

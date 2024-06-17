using MediatR;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.ObterClientes.Dtos;
using Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;

namespace Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.ObterClientes
{
    internal class ObterClientesQuery : IRequestHandler<ObterClientesDto, IEnumerable<ClientesRecuperadosDto>>
    {
        private readonly IClienteRepositorioDapper _clienteRepositorioDapper;
        private readonly IUnityOfWork _unitOfWork;

        public ObterClientesQuery(IClienteRepositorioDapper clienteRepositorioDapper, IUnityOfWork unitOfWork)
        {
            _clienteRepositorioDapper = clienteRepositorioDapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClientesRecuperadosDto>> Handle(ObterClientesDto request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepositorioDapper.GetAllAsync();
            return clientes.Select(cliente => (ClientesRecuperadosDto)cliente);
        }
    }
}

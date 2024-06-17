using Dapper;
using System.Data;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;
using Xp.GestaoPortfolioInvestimentos.Domain.ValueObjects;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Repositorios.Dapper
{
    public class ClienteRepositorioDapper : IClienteRepositorioDapper
    {
        private readonly IDbConnection _dbConnection;

        public ClienteRepositorioDapper(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            string query = "SELECT * FROM portfolio_investimento.Cliente";
            return await _dbConnection.QueryAsync<Cliente>(query);
        }

        public async Task<Cliente?> GetByCpfAsync(string cpf)
        {
            string query = "SELECT * FROM portfolio_investimento.Cliente WHERE Cpf = @cpf";

            var result = await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(query, new { Cpf = cpf });

            var cliente = new Cliente(result.Id, result.Nome, result.Email.Endereco, result.Cpf.Documento);

            return cliente is null ? null : cliente;
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            string query = "SELECT * FROM portfolio_investimento.Cliente WHERE Id = @id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(query, new { Id = id });
        }
    }
}

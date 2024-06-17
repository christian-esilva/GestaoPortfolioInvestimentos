using Dapper;
using System.Data;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;

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
            string query = "SELECT * FROM Cliente";
            return await _dbConnection.QueryAsync<Cliente>(query);
        }

        public async Task<Cliente> GetByCpfAsync(string cpf)
        {
            string query = "SELECT * FROM Cliente WHERE Cpf = @cpf";
            return await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(query, new { Cpf = cpf });
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            string query = "SELECT * FROM Cliente WHERE Id = @id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(query, new { Id = id });
        }
    }
}

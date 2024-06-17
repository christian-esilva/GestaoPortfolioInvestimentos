using Dapper;
using System.Data;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Repositorios.Dapper;

public class InvestimentoRepositorioDapper : IInvestimentoRepositorioDapper
{
    private readonly IDbConnection _dbConnection;

    public InvestimentoRepositorioDapper(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Investimento> ObterPorId(Guid id)
    {
        string query = "SELECT * FROM portfolio_investimento.Investimento WHERE Id = @id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Investimento>(query, new { Id = id });
    }

    public async Task<Investimento> ObterPorProdutoInvestimentoECliente(Guid produtoInvestimentoId, Guid clienteId)
    {
        string query = "SELECT * FROM portfolio_investimento.Investimento WHERE ClienteId = @clienteId";
        return await _dbConnection.QueryFirstOrDefaultAsync<Investimento>(query, new { ClienteId = clienteId, ProdutoInvestimentoId = produtoInvestimentoId });
    }
}

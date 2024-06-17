using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;

public interface IClienteRepositorioDapper
{
    Task<Cliente> GetByIdAsync(Guid id);
    Task<Cliente> GetByCpfAsync(string cpf);
    Task<IEnumerable<Cliente>> GetAllAsync();
}

using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;

namespace Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;

public interface IClienteRepositorio
{
    Task<Cliente> AddAsync(Cliente cliente);
    void UpdateAsync(Cliente cliente);
    Task<Cliente> DeleteAsync(Guid id);
}

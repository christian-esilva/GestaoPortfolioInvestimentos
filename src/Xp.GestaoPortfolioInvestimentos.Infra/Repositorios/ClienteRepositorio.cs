using Microsoft.EntityFrameworkCore;
using Xp.GestaoPortfolioInvestimentos.Domain.Entidades;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Infra.Context;

namespace Xp.GestaoPortfolioInvestimentos.Infra.Repositorios;

public class ClienteRepositorio : IClienteRepositorio
{
    protected readonly AppDbContext _appDbContext;

    public ClienteRepositorio(AppDbContext db)
    {
        _appDbContext = db;
    }

    public async Task<Cliente> AddAsync(Cliente cliente)
    {
        if (cliente == null)
            throw new ArgumentNullException(nameof(cliente));

        await _appDbContext.Clientes.AddAsync(cliente);

        return cliente;
    }

    public async Task<Cliente> DeleteAsync(Guid id)
    {
        var cliente = await GetByIdAsync(id);

        if (cliente == null)
            throw new InvalidOperationException($"{nameof(Cliente)} não encontrado");

        _appDbContext.Clientes.Remove(cliente);
        await _appDbContext.SaveChangesAsync();

        return cliente;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _appDbContext.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetByCpfAsync(string cpf)
    {
        return await _appDbContext.Clientes.Where(x => x.Cpf.Documento == cpf).FirstOrDefaultAsync();
    }

    public async Task<Cliente> GetByIdAsync(Guid id)
    {
        var cliente = await _appDbContext.Clientes.FindAsync(id);

        return cliente ?? throw new InvalidOperationException($"{nameof(Cliente)} não encontrado");
    }

    public void UpdateAsync(Cliente cliente)
    {
        if (cliente == null)
            throw new InvalidOperationException(nameof(cliente));

        _appDbContext.Clientes.Update(cliente);
    }
}

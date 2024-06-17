using System.Data;
using Xp.GestaoPortfolioInvestimentos.Infra.Context;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Infra.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes;
using Xp.GestaoPortfolioInvestimentos.Infra.Repositorios.Dapper;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;

namespace Xp.GestaoPortfolioInvestimentos.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
              this IServiceCollection services,
              IConfiguration configuration)
    {
        var mySqlConnection = configuration
                      .GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
                         options.UseMySql(mySqlConnection,
                         ServerVersion.AutoDetect(mySqlConnection)));

        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new MySqlConnection(mySqlConnection);
            connection.Open();
            return connection;
        });

        services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
        services.AddScoped<IInvestimentoRepositorio, InvestimentoRepositorio>();
        services.AddScoped<IProdutoInvestimentoRepositorio, ProdutoInvestimentoRepositorio>();
        services.AddScoped<IClienteRepositorioDapper, ClienteRepositorioDapper>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var myhandlers = AppDomain.CurrentDomain.Load("Xp.GestaoPortfolioInvestimentos.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

        return services;
    }
}

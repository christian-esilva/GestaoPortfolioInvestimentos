using System.Data;
using Xp.GestaoPortfolioInvestimentos.Infra.Context;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Infra.Repositorios;
using Xp.GestaoPortfolioInvestimentos.Domain.Abstracoes;
using Xp.GestaoPortfolioInvestimentos.Infra.Repositorios.Dapper;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios.Dapper;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Shared;
using System.Reflection;
using FluentValidation;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Dtos;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Validators;

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
        services.AddTransient<IValidator<AdicionarClienteDto>, AdicionarClienteValidator>();

        var myhandlers = AppDomain.CurrentDomain.Load("Xp.GestaoPortfolioInvestimentos.Application");
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(myhandlers);
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("Xp.GestaoPortfolioInvestimentos.Application"));

        return services;
    }
}

using Microsoft.AspNetCore.Mvc;
using Xp.GestaoPortfolioInvestimentos.Domain.Repositorios;

namespace Xp.GestaoPortfolioInvestimentos.Api.Controllers.v1;

[ApiController]
[Route("v1/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ClientesController(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        // TODO - usar mediator
        // var clientes = await _clienteRepositorio.GetAllAsync();
        // return Ok(clientes);
        return Ok();
    }
}

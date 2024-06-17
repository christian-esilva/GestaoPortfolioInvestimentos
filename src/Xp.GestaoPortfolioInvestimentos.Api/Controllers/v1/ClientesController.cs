using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Clientes.Adicionar.Dtos;

namespace Xp.GestaoPortfolioInvestimentos.Api.Controllers.v1;

[ApiController]
[Route("v1/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarCliente([FromBody] AdicionarClienteDto clienteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _mediator.Send(clienteDto);
        return CreatedAtAction(nameof(ClienteAdicionadoDto), new { id = result.Id }, result);
    }
}

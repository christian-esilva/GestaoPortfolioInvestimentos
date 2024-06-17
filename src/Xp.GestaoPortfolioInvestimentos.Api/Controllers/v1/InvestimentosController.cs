using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Comprar.Dtos;
using Xp.GestaoPortfolioInvestimentos.Application.UseCases.Investimentos.Vender.Dtos;

namespace Xp.GestaoPortfolioInvestimentos.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class InvestimentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestimentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Comprar")]
        public async Task<IActionResult> ComprarInvestimento([FromBody] ComprarInvestimentoDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(InvestimentoCompradoDto), new { id = result.InvestimentoId }, result);
        }

        [HttpPost("Vender")]
        public async Task<IActionResult> VenderInvestimento([FromBody] VenderInvestimentoDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(InvestimentoVendidoDto), new { id = result.InvestimentoId }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            return Ok(id);
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult> ObterExtratoPorProduto([FromRoute] Guid produtoId)
        {
            return Ok(produtoId);
        }
    }
}

using Desafio.Bravi.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Bravi.Api.Controllers.ObterCliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string? identificador)
        {
            var response = await _mediator.Send(new ObterClienteCommand(identificador)).ConfigureAwait(true);

            return Ok(response);
        }
    }
}

using Desafio.Bravi.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Bravi.Api.Controllers.RemoverCliente
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

        [HttpDelete("{identificador}")]
        public async Task<IActionResult> Delete(string identificador)
        {
            await _mediator.Send(new RemoverClienteCommand(identificador));

            return Accepted();
        }
    }
}

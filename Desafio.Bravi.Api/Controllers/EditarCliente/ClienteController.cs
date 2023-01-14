using AutoMapper;
using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Bravi.Api.Controllers.EditarCliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<EditarClienteRequest> _validator;
        private readonly IMapper _mapper;

        public ClienteController(IMediator mediator, IValidator<EditarClienteRequest> validator, IMapper mapper)
        {
            _mediator = mediator;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpPut("{identificador}")]
        public async Task<IActionResult> Put(string identificador, [FromBody] EditarClienteRequest request)
        {
            var result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                var erros = new List<string>();
                foreach (var erro in result.Errors)
                    erros.Add(erro.ErrorMessage);

                return BadRequest(erros);
            }

            var cliente = _mapper.Map<Cliente>(request);
            cliente.Identificador = identificador;

            await _mediator.Send(new EditarClienteCommand(cliente)).ConfigureAwait(true);

            return Accepted();
        }
    }
}

using AutoMapper;
using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Bravi.Api.Controllers.CriarCliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CriarClienteRequest> _validator;
        private readonly IMapper _mapper;
        public ClienteController(IMediator mediator, IValidator<CriarClienteRequest> validator, IMapper mapper)
        {
            _mediator = mediator;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarClienteRequest request)
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

            var response = await _mediator.Send(new AdicionarClienteCommand(cliente)).ConfigureAwait(true);

            return Accepted(response);
        }
    }
}

using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository;
using MediatR;

namespace Desafio.Bravi.Application.Handlers
{
    public class ObterClienteHandler : IRequestHandler<ObterClienteCommand, IEnumerable<Cliente>>
    {
        private readonly IObterClienteRepository _repository;
        public ObterClienteHandler(IObterClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cliente>> Handle(ObterClienteCommand request, CancellationToken cancellationToken)
        {
            var clientes = null as IEnumerable<Cliente>;
            if (!string.IsNullOrWhiteSpace(request.Identificador))
            {
                clientes = await _repository.ObterClientePorIdentificador(request.Identificador);
            }
            else
            {
                clientes = await _repository.ObterClientes();
            }

            return clientes;
        }
    }
}

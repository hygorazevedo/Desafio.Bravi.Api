using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository;
using MediatR;

namespace Desafio.Bravi.Application.Handlers
{
    public class AdicionarClienteHandler : IRequestHandler<AdicionarClienteCommand, Cliente>
    {
        private readonly IAdicionarClienteRepository _repository;
        public AdicionarClienteHandler(IAdicionarClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.AdicionarCliente(request.Cliente);

            return cliente;
        }
    }
}

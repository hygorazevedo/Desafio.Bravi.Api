using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Repository;
using MediatR;

namespace Desafio.Bravi.Application.Handlers
{
    public class EditarClienteHandler : IRequestHandler<EditarClienteCommand>
    {
        private readonly IEditarClienteRepository _repository;
        public EditarClienteHandler(IEditarClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(EditarClienteCommand request, CancellationToken cancellationToken)
        {
            await _repository.EditarCliente(request.Cliente);

            return await Task.FromResult(Unit.Value);
        }
    }
}

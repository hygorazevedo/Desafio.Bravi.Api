using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Repository;
using MediatR;

namespace Desafio.Bravi.Application.Handlers
{
    public class RemoverClienteHandler : IRequestHandler<RemoverClienteCommand>
    {
        private readonly IRemoverClienteRepository _repository;
        public RemoverClienteHandler(IRemoverClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoverCliente(request.Identificador);

            return await Task.FromResult(Unit.Value);
        }
    }
}

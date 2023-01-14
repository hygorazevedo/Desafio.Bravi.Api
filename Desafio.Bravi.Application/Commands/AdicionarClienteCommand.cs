using Desafio.Bravi.Domain.Models;
using MediatR;

namespace Desafio.Bravi.Application.Commands
{
    public class AdicionarClienteCommand : IRequest<Cliente>
    {
        public Cliente Cliente { get; set; }

        public AdicionarClienteCommand(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}

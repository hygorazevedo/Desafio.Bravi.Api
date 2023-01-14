using Desafio.Bravi.Domain.Models;
using MediatR;

namespace Desafio.Bravi.Application.Commands
{
    public class EditarClienteCommand : IRequest
    {
        public Cliente Cliente { get; set; }

        public EditarClienteCommand(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}

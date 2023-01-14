using Desafio.Bravi.Domain.Models;
using MediatR;

namespace Desafio.Bravi.Application.Commands
{
    public class ObterClienteCommand : IRequest<IEnumerable<Cliente>>
    {
        public string Identificador { get; set; }

        public ObterClienteCommand(string identificador)
        {
            Identificador = identificador;
        }
    }
}

using MediatR;

namespace Desafio.Bravi.Application.Commands
{
    public class RemoverClienteCommand : IRequest
    {
        public string Identificador { get; set; }

        public RemoverClienteCommand(string identificador)
        {
            Identificador = identificador;
        }
    }
}

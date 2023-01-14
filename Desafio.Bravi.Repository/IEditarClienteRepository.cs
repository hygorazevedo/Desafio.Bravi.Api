using Desafio.Bravi.Domain.Models;

namespace Desafio.Bravi.Repository
{
    public interface IEditarClienteRepository
    {
        Task EditarCliente(Cliente cliente);
    }
}

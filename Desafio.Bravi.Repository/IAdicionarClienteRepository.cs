using Desafio.Bravi.Domain.Models;

namespace Desafio.Bravi.Repository
{
    public interface IAdicionarClienteRepository
    {
        Task<Cliente> AdicionarCliente(Cliente cliente);
    }
}

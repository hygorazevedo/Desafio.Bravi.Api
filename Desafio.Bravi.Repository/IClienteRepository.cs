using Desafio.Bravi.Domain.Models;

namespace Desafio.Bravi.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> ObterClienteByIdentificador(Guid identificador);
        Task<Cliente> ObterClientes();
    }
}

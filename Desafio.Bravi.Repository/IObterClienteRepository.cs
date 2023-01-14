using Desafio.Bravi.Domain.Models;

namespace Desafio.Bravi.Repository
{
    public interface IObterClienteRepository
    {
        Task<IEnumerable<Cliente>> ObterClientePorIdentificador(string identificador);
        Task<IEnumerable<Cliente>> ObterClientes();
    }
}

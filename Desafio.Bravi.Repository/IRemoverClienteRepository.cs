namespace Desafio.Bravi.Repository
{
    public interface IRemoverClienteRepository
    {
        Task RemoverCliente(string identificador);
    }
}

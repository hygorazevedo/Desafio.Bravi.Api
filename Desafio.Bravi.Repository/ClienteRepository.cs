using AutoMapper;
using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository.EntityModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Desafio.Bravi.Repository
{
    public class ClienteRepository : IObterClienteRepository, IAdicionarClienteRepository, IEditarClienteRepository, IRemoverClienteRepository
    {
        private readonly IMongoCollection<ECliente> _colecao;
        private readonly IMapper _mapper;

        public ClienteRepository(IMongoClient client, IMapper mapper)
        {
            _mapper = mapper;

            var database = client.GetDatabase("bravidb");

            _colecao = database.GetCollection<ECliente>("cliente");
        }

        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            var data = _mapper.Map<ECliente>(cliente);
            data.Identificador = ObjectId.GenerateNewId().ToString();
            await _colecao.InsertOneAsync(data);

            cliente.Identificador = data.Identificador;

            return cliente;
        }

        public async Task EditarCliente(Cliente cliente)
        {
            var data = _mapper.Map<ECliente>(cliente);
            data.Identificador = ObjectId.GenerateNewId().ToString();

            var filter = Builders<ECliente>.Filter.Eq("_id", ObjectId.Parse(cliente.Identificador));
            var update = Builders<ECliente>.Update.Set("Nome", cliente.Nome)
                                                  .Set("Telefone", cliente.Telefone)
                                                  .Set("Email", cliente.Email)
                                                  .Set("WhatsApp", cliente.WhatsApp);
            await _colecao.UpdateOneAsync(filter, update);
        }

        public Task<IEnumerable<Cliente>> ObterClientePorIdentificador(string identificador)
        {
            var query = from e in _colecao.AsQueryable<ECliente>()
                        where e.Identificador == identificador
                        select e;

            var list = _mapper.Map<IEnumerable<Cliente>>(query);

            return Task.FromResult(list);
        }

        public Task<IEnumerable<Cliente>> ObterClientes()
        {
            var query = from e in _colecao.AsQueryable<ECliente>()
                        select e;

            var list = _mapper.Map<IEnumerable<Cliente>>(query);

            return Task.FromResult(list);
        }

        public async Task RemoverCliente(string identificador)
        {
            var filter = Builders<ECliente>.Filter.Eq("_id", ObjectId.Parse(identificador));
            await _colecao.DeleteOneAsync(filter);
        }
    }
}

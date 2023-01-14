using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Application.Handlers;
using Desafio.Bravi.Application.SpecFlow.Support;
using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository;

namespace Desafio.Bravi.Application.SpecFlow.StepDefinitions
{
    [Binding]
    public class ObterClienteHandlerStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly IObterClienteRepository _repository;

        public ObterClienteHandlerStepDefinitions(ScenarioContext context)
        {
            _context = context;
            _repository = ObterClienteRepositoryMock.CreateMock();
        }

        [Given(@"que seja informado o identificador '([^']*)'")]
        public void GivenQueSejaInformadoOIdentificador(string p0)
        {
            _context["identificador"] = p0;
        }

        [When(@"consulta os clientes")]
        public async void WhenConsultaOsClientes()
        {
            var identificador = _context["identificador"] as string;

            var handler = new ObterClienteHandler(_repository);
            var response = await handler.Handle(new ObterClienteCommand(identificador), new CancellationToken());

            _context["response"] = response;
        }

        [Then(@"retorna a lista completa de clientes")]
        public void ThenRetornaAListaCompletaDeClientes()
        {
            var response = _context["response"] as IEnumerable<Cliente>;

            Assert.NotNull(response);
            Assert.True(response?.Any());
            Assert.Equal(1, response?.Count());
            Assert.Equal("63be59af70be3df5ab1ae2a8", response?.First().Identificador);
        }

        [Then(@"retorna a lista de clientes vazia")]
        public void ThenRetornaAListaDeClientesVazia()
        {
            var response = _context["response"] as IEnumerable<Cliente>;

            Assert.NotNull(response);
            Assert.False(response?.Any());
            Assert.Equal(0, response?.Count());
        }

    }
}

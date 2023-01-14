using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Application.Handlers;
using Desafio.Bravi.Application.SpecFlow.Support;
using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository;
using MediatR;

namespace Desafio.Bravi.Application.SpecFlow.StepDefinitions
{
    [Binding]
    public class EditarClienteHandlerStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly IEditarClienteRepository _repository;

        public EditarClienteHandlerStepDefinitions(ScenarioContext context)
        {
            _context = context;
            _repository = EditarClienteRepositoryMock.CreateMock();
        }

        [Given(@"que sejam informados os dados na edicao")]
        public void GivenQueSejamInformadosOsDadosNaEdicao(Table table)
        {
            var dicionario = Conversor.ToDictionary(table);
            var identificador = dicionario["Identificador"];
            var nome = dicionario["Nome"];
            var codigoAreaTelefone = dicionario["CodigoAreaTelefone"];
            var numeroTelefone = dicionario["NumeroTelefone"];
            var email = dicionario["Email"];
            var codigoAreaWhatsApp = dicionario["CodigoAreaWhatsApp"];
            var umeroWhatsApp = dicionario["NumeroWhatsApp"];

            var cliente = new Cliente();

            if (!string.IsNullOrWhiteSpace(identificador))
            {
                cliente.Identificador = identificador;
            }

            if (!string.IsNullOrWhiteSpace(nome))
            {
                cliente.Nome = nome;
            }

            if (!string.IsNullOrWhiteSpace(codigoAreaTelefone) && !string.IsNullOrWhiteSpace(numeroTelefone))
            {
                cliente.Telefone = new Telefone
                {
                    CodigoDiscagem = int.Parse(codigoAreaTelefone),
                    Numero = numeroTelefone
                };
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                cliente.Email = email;
            }

            if (!string.IsNullOrWhiteSpace(codigoAreaWhatsApp) && !string.IsNullOrWhiteSpace(umeroWhatsApp))
            {
                cliente.WhatsApp = new Telefone
                {
                    CodigoDiscagem = int.Parse(codigoAreaWhatsApp),
                    Numero = umeroWhatsApp
                };
            }

            _context["cliente"] = cliente;
        }

        [When(@"editar o cliente")]
        public async void WhenEditarOCliente()
        {
            var cliente = _context["cliente"] as Cliente;
            var handler = new EditarClienteHandler(_repository);
            var response = handler.Handle(new EditarClienteCommand(cliente), new CancellationToken());

            _context["response"] = response;
        }

        [Then(@"a edicao sera encerrada sem erros")]
        public void ThenATarefaSeraEncerradaSemErros()
        {
            var task = _context["response"] as Task<Unit>;

            Assert.True(task?.IsCompleted);
        }
    }
}

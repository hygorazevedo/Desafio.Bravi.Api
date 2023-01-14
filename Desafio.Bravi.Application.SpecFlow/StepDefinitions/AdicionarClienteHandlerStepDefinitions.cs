using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Application.Handlers;
using Desafio.Bravi.Application.SpecFlow.Support;
using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository;
using MediatR;
using System;
using TechTalk.SpecFlow;

namespace Desafio.Bravi.Application.SpecFlow.StepDefinitions
{
    [Binding]
    public class AdicionarClienteHandlerStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly IAdicionarClienteRepository _repository;

        public AdicionarClienteHandlerStepDefinitions(ScenarioContext context)
        {
            _context = context;
            _repository = AdicionarClienteRepositoryMock.CreateMock();
        }

        [Given(@"que sejam informados os dados no cadastrado")]
        public void GivenQueSejamInformadosOsDadosNoCadastrado(Table table)
        {
            var dicionario = Conversor.ToDictionary(table);
            var nome = dicionario["Nome"];
            var codigoAreaTelefone = dicionario["CodigoAreaTelefone"];
            var numeroTelefone = dicionario["NumeroTelefone"];
            var email = dicionario["Email"];
            var codigoAreaWhatsApp = dicionario["CodigoAreaWhatsApp"];
            var umeroWhatsApp = dicionario["NumeroWhatsApp"];

            var cliente = new Cliente();

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

        [When(@"adicionar o cliente")]
        public async void WhenAdicionarOCliente()
        {
            var cliente = _context["cliente"] as Cliente;
            var handler = new AdicionarClienteHandler(_repository);
            var response = await handler.Handle(new AdicionarClienteCommand(cliente), new CancellationToken());

            _context["response"] = response;
        }

        [Then(@"o identificador do cliente sera preenchido")]
        public void ThenOIdentificadorDoClienteSeraPreenchido()
        {
            var cliente = _context["response"] as Cliente;
            
            Assert.NotNull(cliente);
            Assert.Equal("63be59af70be3df5ab1ae2a8", cliente?.Identificador);
        }
    }
}

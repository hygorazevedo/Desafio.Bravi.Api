using Desafio.Bravi.Application.Commands;
using Desafio.Bravi.Application.Handlers;
using Desafio.Bravi.Application.SpecFlow.Support;
using Desafio.Bravi.Repository;
using MediatR;
using System;
using TechTalk.SpecFlow;

namespace Desafio.Bravi.Application.SpecFlow.StepDefinitions
{
    [Binding]
    public class RemoverClienteHandlerStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly IRemoverClienteRepository _repository;

        public RemoverClienteHandlerStepDefinitions(ScenarioContext context)
        {
            _context = context;
            _repository = RemoverClienteRepositoryMock.CreateMock();
        }

        [Given(@"que ao remover um cliente seja informado o identificador '([^']*)'")]
        public void GivenQueAoRemoverUmClienteSejaInformadoOIdentificador(string p0)
        {
            _context["identificador"] = p0;
        }

        [When(@"remover o cliente")]
        public void WhenRemoverOCliente()
        {
            var identificador = _context["identificador"] as string;

            var handler = new RemoverClienteHandler(_repository);
            var response = handler.Handle(new RemoverClienteCommand(identificador), new CancellationToken());

            _context["response"] = response;
        }

        [Then(@"a exclusao será encerrada sem erros")]
        public void ThenAExclusaoSeraEncerradaSemErros()
        {
            var task = _context["response"] as Task<Unit>;

            Assert.True(task?.IsCompleted);
        }
    }
}

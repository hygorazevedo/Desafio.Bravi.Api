using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository;
using Moq;

namespace Desafio.Bravi.Application.SpecFlow.Support
{
    internal class ObterClienteRepositoryMock
    {
        public static IObterClienteRepository CreateMock()
        {
            var mock = new Mock<IObterClienteRepository>();
            mock.Setup(x => x.ObterClientes())
                .Returns(Task.FromResult(GetClientesCadastrados()));

            mock.Setup(x => x.ObterClientePorIdentificador(It.Is<string>(p => p == "63be59af70be3df5ab1ae2a8")))
                .Returns(Task.FromResult(GetClientesCadastrados()));

            return mock.Object;
        }

        private static IEnumerable<Cliente> GetClientesCadastrados()
        {
            var clientes = new List<Cliente>();
            clientes.Add(new Cliente
            {
                Identificador = "63be59af70be3df5ab1ae2a8",
                Nome = "Hygor de Lima Azevedo",
                Telefone = new Telefone
                {
                    CodigoDiscagem = 31,
                    Numero = "998765432"
                },
                Email = "hygor.azevedo@desafio.bravi",
                WhatsApp = new Telefone
                {
                    CodigoDiscagem = 31,
                    Numero = "998765432"
                }
            });

            return clientes;
        }
    }
}

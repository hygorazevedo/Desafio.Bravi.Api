using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository;
using Moq;

namespace Desafio.Bravi.Application.SpecFlow.Support
{
    internal static class AdicionarClienteRepositoryMock
    {
        private static Mock<IAdicionarClienteRepository> mock;

        public static IAdicionarClienteRepository CreateMock()
        {
            mock = new Mock<IAdicionarClienteRepository>();
            mock.Setup(x => x.AdicionarCliente(It.Is<Cliente>(p => p.Nome == "Hygor de Lima Azevedo" && p.Telefone.Numero == "998765432" && p.Email == "hygor.azevedo@desafio.bravi" && p.WhatsApp.Numero == "998765432")))
                .Returns(Task.FromResult(GetAdicionarClienteCadastrado()));

            return mock.Object;
        }

        private static Cliente GetAdicionarClienteCadastrado()
        {
            return new Cliente
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
            };
        }
    }
}

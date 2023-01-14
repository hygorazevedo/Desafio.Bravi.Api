using Desafio.Bravi.Domain.Models;
using Desafio.Bravi.Repository;
using Moq;

namespace Desafio.Bravi.Application.SpecFlow.Support
{
    internal static class EditarClienteRepositoryMock
    {
        public static IEditarClienteRepository CreateMock()
        {
            var mock = new Mock<IEditarClienteRepository>();
            mock.Setup(x => x.EditarCliente(It.Is<Cliente>(p => p.Identificador == "63bf0533315982662670330f")))
                .Verifiable();

            return mock.Object;
        }
    }
}

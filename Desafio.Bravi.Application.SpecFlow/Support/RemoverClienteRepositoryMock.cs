using Desafio.Bravi.Repository;
using Moq;

namespace Desafio.Bravi.Application.SpecFlow.Support
{
    internal static class RemoverClienteRepositoryMock
    {
        public static IRemoverClienteRepository CreateMock()
        {
            var mock = new Mock<IRemoverClienteRepository>();
            mock.Setup(x => x.RemoverCliente(It.Is<string>(p => p == "63bf0533315982662670330f")))
                .Verifiable();

            return mock.Object;
        }
    }
}

using Desafio.Bravi.Domain.Models;

namespace Desafio.Bravi.Api.Controllers.EditarCliente
{
    public class EditarClienteRequest
    {
        public string Nome { get; set; }
        public Telefone? Telefone { get; set; }
        public string? Email { get; set; }
        public Telefone? WhatsApp { get; set; }
    }
}

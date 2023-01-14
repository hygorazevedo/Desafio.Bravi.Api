using Desafio.Bravi.Domain.Models;

namespace Desafio.Bravi.Api.Controllers.CriarCliente
{
    public class CriarClienteRequest
    {
        public string? Nome { get; set; }
        public Telefone? Telefone { get; set; }
        public string? Email { get; set; }
        public Telefone? WhatsApp { get; set; }
    }
}

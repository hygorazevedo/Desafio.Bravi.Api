namespace Desafio.Bravi.Api.Controllers.ObterCliente
{
    public class ObterClienteResponse
    {
        public Guid Identificador { get; set; }
        public string Nome { get; set; }
        public ObterClienteResponseInnerTelefone? Telefone { get; set; }
        public string? Email { get; set; }
        public ObterClienteResponseInnerTelefone? WhatsApp { get; set; }
    }

    public class ObterClienteResponseInnerTelefone
    {
        public short CodigoDiscagem { get; set; }
        public string Numero { get; set; }
    }
}

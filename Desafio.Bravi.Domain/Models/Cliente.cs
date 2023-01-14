namespace Desafio.Bravi.Domain.Models
{
    public class Cliente
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public Telefone Telefone { get; set; }
        public string Email { get; set; }
        public Telefone WhatsApp { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Desafio.Bravi.Repository.EntityModels
{
    [BsonIgnoreExtraElements]
    internal class ECliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Identificador { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Telefone")]
        public ETelefone Telefone { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("WhatsApp")]
        public ETelefone WhatsApp { get; set; }
    }
}

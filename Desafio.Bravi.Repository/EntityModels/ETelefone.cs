using MongoDB.Bson.Serialization.Attributes;

namespace Desafio.Bravi.Repository.EntityModels
{
    internal class ETelefone
    {
        [BsonElement("CodigoDiscagem")]
        public int CodigoDiscagem { get; set; }
        [BsonElement("Numero")]
        public string Numero { get; set; }
    }
}

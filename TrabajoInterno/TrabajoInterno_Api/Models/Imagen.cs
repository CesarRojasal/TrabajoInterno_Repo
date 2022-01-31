using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrabajoInterno_Api.Models
{
    public class Imagen
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("id_persona")]
        public int Id_Persona { get; set; }

        [BsonElement("nombre")]
        public string? Nombre { get; set; }

        [BsonElement("imagen")]
        public string? ImagenData { get; set; }
    }
}

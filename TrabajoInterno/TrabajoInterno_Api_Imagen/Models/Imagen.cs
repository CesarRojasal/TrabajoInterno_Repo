using MongoDB.Bson.Serialization.Attributes;

namespace TrabajoInterno_Api_Imagen.Models
{
    public class Imagen
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("id_persona")]
        [BsonRequired]
        public int Id_Persona { get; set; }

        [BsonRequired]
        [BsonElement("nombre")]
        public string? Nombre { get; set; }

        [BsonRequired]
        [BsonElement("imagen")]
        public string? ImagenData { get; set; }
    }
}

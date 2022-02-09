using MongoDB.Bson.Serialization.Attributes;

namespace TrabajoInterno_Api_Persona.Remote.RemoteModel
{
    public class RemoteImagen
    {
        public string Id { get; set; } = string.Empty;

        public int Id_Persona { get; set; }

        public string? Nombre { get; set; }

        public string? ImagenData { get; set; }
    }
}

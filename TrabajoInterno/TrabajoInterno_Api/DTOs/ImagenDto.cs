using System.ComponentModel.DataAnnotations;

namespace TrabajoInterno_Api.DTOs
{
    public class ImagenDto
    {
        public string? Id { get; set; }
        [Required]
        public int Id_Persona { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? ImagenData { get; set; }
    }
}

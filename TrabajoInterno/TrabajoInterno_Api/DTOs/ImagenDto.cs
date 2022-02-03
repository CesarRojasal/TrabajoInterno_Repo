using System.ComponentModel.DataAnnotations;

namespace TrabajoInterno_Api.DTOs
{
    public class ImagenDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "El campo  Id_Persona es requerido")]
        public int Id_Persona { get; set; }
        [Required(ErrorMessage = "El campo  Nombre es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo  Imagen es requerido")]
        public string? ImagenData { get; set; }
    }
}

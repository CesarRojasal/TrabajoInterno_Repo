using System.ComponentModel.DataAnnotations;

namespace TrabajoInterno_Api.DTOs
{
    public class PersonaDto
    {

        public int IdPersona { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Apellido { get; set; }

        [Required(ErrorMessage ="El campo  Identificacion es requerido")]
        public string? Identificacion { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public string? CiudadNacimiento { get; set; }

        [Required]
        public string? Correo { get; set; }

        public bool Activo { get; set; }

        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaActualizacion { get; set; } = DateTime.Now;
    }
}

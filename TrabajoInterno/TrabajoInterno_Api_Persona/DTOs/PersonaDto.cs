using System.ComponentModel.DataAnnotations;

namespace TrabajoInterno_Api_Persona.DTOs
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El campo  Nombre es requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo  Apellido es requerido")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo  Identificacion es requerido")]
        public string? Identificacion { get; set; }

        [Required(ErrorMessage = "El campo  Edad es requerido")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo  CiudadNacimiento es requerido")]
        public string? CiudadNacimiento { get; set; }

        [Required(ErrorMessage = "El campo  Correo es requerido")]
        public string? Correo { get; set; }
        //public string PersonaGuid { get; set; } = Guid.NewGuid().ToString();
    }
}

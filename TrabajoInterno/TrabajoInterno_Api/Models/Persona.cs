using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrabajoInterno_Api.Models
{
    public partial class Persona
    {
        [Key]
        [Display(Name = "id_persona")]
        public int IdPersona { get; set; }
        [Required]
        [Display(Name = "nombre")]
        public string? Nombre { get; set; }
        [Required]
        [Display(Name = "apellido")]
        public string? Apellido { get; set; }
        [Required]
        [Display(Name = "identificacion")]
        public string? Identificacion { get; set; } 
        [Required]
        [Display(Name = "edad")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "ciudad_Nacimiento")]
        public string? CiudadNacimiento { get; set; }
        [Required]
        [Display(Name = "correo")]
        public string? Correo { get; set; }
        [Display(Name = "activo")]
        public bool Activo { get; set; }
        [Display(Name = "fecha_creacion")]
        public DateTime? FechaCreacion { get; set; }
        [Display(Name = "fecha_actualizacion")]
        public DateTime? FechaActualizacion { get; set; }

    }
}

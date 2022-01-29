using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrabajoInterno_Api.Models
{
    public partial class Persona
    {
        public Persona()
        {
        }

        /// <summary>
        /// Id persona
        /// </summary>
        [Display(Name = "id_persona")]
        [Key]
        public int IdPersona { get; set; }
        /// <summary>
        /// Nombre persona
        /// </summary>
        [Required]
        [Display(Name = "nombre")]
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Apellidos persona
        /// </summary>
        [Required]
        [Display(Name = "apellido")]
        public string Apellido { get; set; } = null!;
        /// <summary>
        /// Identificacion persona
        /// </summary>
        [Required]
        [Display(Name = "identificacion")]
        public string Identificacion { get; set; } = null!;
        /// <summary>
        /// Edad persona
        /// </summary>
        [Required]
        [Display(Name = "edad")]
        public int Edad { get; set; }
        /// <summary>
        /// Ciudad de nacimiento persona
        /// </summary>
        [Required]
        [Display(Name = "ciudad_Nacimiento")]
        public string CiudadNacimiento { get; set; } = null!;
        /// <summary>
        /// Correo
        /// </summary>
        [Required]
        [Display(Name = "correo")]
        public string Correo { get; set; } = null!;
        /// <summary>
        /// Persona activa
        /// </summary>
        [Display(Name = "activo")]
        public bool Activo { get; set; }
        /// <summary>
        /// fecha de creacion
        /// </summary>
        [Display(Name = "fecha_creacion")]
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// fecha de ultima actualizacion
        /// </summary>
        [Display(Name = "fecha_actualizacion")]
        public DateTime? FechaActualizacion { get; set; }

    }
}

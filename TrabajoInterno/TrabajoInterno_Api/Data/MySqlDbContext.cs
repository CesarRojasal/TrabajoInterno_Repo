using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Data
{
    public partial class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options){}

        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Persona>(entity =>
            {
              
                entity.ToTable("persona");
                entity.HasKey(p => p.IdPersona);

                entity.Property(e => e.IdPersona)
                    .HasColumnName("id_persona")
                    .HasComment("Id persona");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasComment("Persona activa");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .HasColumnName("apellido")
                    .HasComment("Apellidos persona");

                entity.Property(e => e.CiudadNacimiento)
                    .HasMaxLength(30)
                    .HasColumnName("ciudad_Nacimiento")
                    .HasComment("Ciudad de nacimiento persona");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo")
                    .HasComment("Correo");

                entity.Property(e => e.Edad)
                    .HasColumnName("edad")
                    .HasComment("Edad persona");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion")
                    .HasComment("fecha de ultima actualizacion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion")
                    .HasComment("fecha de creacion");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(30)
                    .HasColumnName("identificacion")
                    .HasComment("Identificacion persona");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .HasColumnName("nombre")
                    .HasComment("Nombre persona");
            });

        }

    }
}

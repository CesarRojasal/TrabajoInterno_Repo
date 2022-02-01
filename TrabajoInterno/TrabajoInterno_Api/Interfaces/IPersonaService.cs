﻿using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Interfaces
{
    public interface IPersonaService: IGenericService<Persona>
    {
        Task<bool> PersonaExists(int id);
        Task<bool> PersonaExistsByIdentificacion(string identificacion);
        Task<List<Persona>> GetPersonaByEdadMayorIgual(int edad);
        Task<Persona> GetPersonaByIdentificacion(string identificacion);
    }
}
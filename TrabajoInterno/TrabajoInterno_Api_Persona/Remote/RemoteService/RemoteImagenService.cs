using System.Text.Json;
using TrabajoInterno_Api_Persona.Remote.RemoteInterface;

namespace TrabajoInterno_Api_Persona.Remote.RemoteService
{
    public class RemoteImagenService :  IRemoteImagenService
    {
        private readonly IHttpClientFactory httpClient;
        public RemoteImagenService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> DeleteImagenByIdPersona(int idPersona)
        {
            try
            {
                var cliente = httpClient.CreateClient("Imagenes");
                var response = await cliente.DeleteAsync($"api/Imagen/ByPersona/{idPersona}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<int>(contenido, options);
                    return resultado;
                }
                throw new Exception("Error al conectarse con el servicio de Imagenes");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

using TrabajoInterno_RabbitMq_Bus.Events;

namespace TrabajoInterno_RabbitMq_Bus.EventoQueue
{
    public class EmailEventoQueue : Evento
    {
        public string Destinatario { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public EmailEventoQueue(string destinatario, string titulo, string contenido)
        {
            Destinatario = destinatario;
            Titulo = titulo;
            Contenido = contenido;
        }

    }
}
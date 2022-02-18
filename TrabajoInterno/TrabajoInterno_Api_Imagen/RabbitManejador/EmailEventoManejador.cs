using TrabajoInterno_RabbitMq_Bus.BusRabbit;
using TrabajoInterno_RabbitMq_Bus.EventoQueue;

namespace TrabajoInterno_Api_Imagen.RabbitManejador
{
    public class EmailEventoManejador : IEventoManejador<EmailEventoQueue>
    {
        public Task Handle(EmailEventoQueue @event)
        {
            return Task.CompletedTask;
        }
    }
}

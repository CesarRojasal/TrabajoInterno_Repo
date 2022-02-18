using TrabajoInterno_RabbitMq_Bus.Commands;
using TrabajoInterno_RabbitMq_Bus.Events;

namespace TrabajoInterno_RabbitMq_Bus.BusRabbit
{
    public interface IRabbitEventBus
    {
        Task EnviarComando<T>(T comando) where T : Comando;

        void Publish<T>(T @evento) where T : Evento;

        void Subscribe<T, TH>() where T : Evento
                                where TH : IEventoManejador<T>;

    }
}

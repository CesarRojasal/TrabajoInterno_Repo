using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoInterno_RabbitMq_Bus.Events;

namespace TrabajoInterno_RabbitMq_Bus.BusRabbit
{
    public interface IEventoManejador<in TEvent> : IEventoManejador where TEvent : Evento
    {
        Task Handle(TEvent @event);
    }

    public interface IEventoManejador
    {

    }

}
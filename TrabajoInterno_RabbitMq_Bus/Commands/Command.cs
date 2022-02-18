using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoInterno_RabbitMq_Bus.Events;

namespace TrabajoInterno_RabbitMq_Bus.Commands
{
    public abstract class Comando : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Comando()
        {
            Timestamp = DateTime.Now;
        }
    }
}

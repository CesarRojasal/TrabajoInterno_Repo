using System.Diagnostics;

namespace TrabajoInterno_Api_Gateway.MessageHandler
{
    public class PersonaHandler: DelegatingHandler
    {
        private readonly ILogger<PersonaHandler> _logger;
        public PersonaHandler(ILogger<PersonaHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tiempo = Stopwatch.StartNew();
            _logger.LogInformation("Inicia request");
            var response = await base.SendAsync(request, cancellationToken);

            _logger.LogInformation($"Este proceso se hizo en {tiempo.ElapsedMilliseconds}ms");

            return response;
        }
    }
}

using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using TrabajoInterno_Api_Gateway.MessageHandler;

var builder = WebApplication.CreateBuilder(args);

new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config
            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            .AddJsonFile("ocelot.json")
            .AddEnvironmentVariables();
    })
    .ConfigureServices(s => {
        s.AddHttpClient("", config => {
            config.BaseAddress = new Uri(builder.Configuration["Services:Persona"]);
        });
        s.AddOcelot().AddDelegatingHandler<PersonaHandler>();
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        //add your logging
    })
    .UseIISIntegration()
    .Configure(app =>
    {
        app.UseOcelot().Wait();
    })
    .Build()
    .Run();

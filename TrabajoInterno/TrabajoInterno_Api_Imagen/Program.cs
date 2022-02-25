using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using TrabajoInterno_Api_Imagen.Data;
using TrabajoInterno_Api_Imagen.Interfaces;
//using TrabajoInterno_Api_Imagen.RabbitManejador;
using TrabajoInterno_Api_Imagen.Repository;
//using TrabajoInterno_RabbitMq_Bus.BusRabbit;
//using TrabajoInterno_RabbitMq_Bus.EventoQueue;
//using TrabajoInterno_RabbitMq_Bus.Implement;
using TrabajoInterno_Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Use Rabbitmq 
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//builder.Services.AddTransient<IEventoManejador<EmailEventoQueue>, EmailEventoManejador>();
//builder.Services.AddTransient<IRabbitEventBus, RabbitEventBus>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    }
);
builder.Services.AddAuthorization();

//Add inyeccion de DBContext Service
builder.Services.Configure<ConnectionMdbSettings>(
    builder.Configuration.GetSection("MongoDBTrabajoInternoSettings"));
builder.Services.AddSingleton<IConnectionMdbSettings>
                (d => d.GetRequiredService<IOptions<ConnectionMdbSettings>>().Value);

//Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Use Json
builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

//Injeccion de dependencias
builder.Services.AddScoped<IImagenService, ImagenService>();
builder.Services.AddScoped<IImagenRepository, ImagenRepository>();
builder.Services.AddSingleton(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var eventBus = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IRabbitEventBus>();
//eventBus.Subscribe<EmailEventoQueue, EmailEventoManejador>();

app.UseAuthorization();
app.UseAuthentication();

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using TrabajoInterno_Api_Persona.Data;
using TrabajoInterno_Api_Persona.Interfaces;
using TrabajoInterno_Api_Persona.Remote.RemoteInterface;
using TrabajoInterno_Api_Persona.Remote.RemoteService;
using TrabajoInterno_Api_Persona.Repository;
using TrabajoInterno_Api_Persona.Services;
//using TrabajoInterno_RabbitMq_Bus.BusRabbit;
//using TrabajoInterno_RabbitMq_Bus.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Use RabbitMQ
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
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

//Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Use Json
builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

//Injeccion de dependencias
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IRemoteImagenService, RemoteImagenService>();
builder.Services.AddSingleton(builder.Configuration);


//Add inyeccion de DBContext Service

builder.Services.AddDbContext<MySqlDbContext>(
options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySQLTrabajoInternoAppCon");
    options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions =>
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null));
});

//HttpClient
builder.Services.AddHttpClient("Imagenes", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Imagenes"]);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

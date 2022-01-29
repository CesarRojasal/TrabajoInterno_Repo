using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TrabajoInterno_Api.Data;
using TrabajoInterno_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add inyeccion de DBContext Service
builder.Services.AddDbContext<MySqlDbContext>(
options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySQLTrabajoInternoAppCon"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
});

//Use Json
builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<PersonaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

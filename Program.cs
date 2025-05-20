using InnovaTubeWebAPI.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");

builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(politica =>
    {
        politica.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });
});

//builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
//    opciones.UseSqlServer("name=DefaultConnection"));

var connectionStrings = builder.Configuration.GetValue<string>("ConnectionStrings");
builder.Services.AddDbContext<ApplicationDbContext>(opciones => 
    opciones.UseNpgsql("name=DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

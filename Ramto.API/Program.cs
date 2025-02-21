using Microsoft.EntityFrameworkCore;
using Ramto.Infraestructura.Repositories;
using Ramto.Infraestructura.Data;
using Ramto.Infraestructura.Repositories;
using Ramto.Lib.Helpers;
using  Ramto.Lib.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Obtener Cadena de Conexion
Configuraciones.CadenaConexion = builder.Configuration.GetConnectionString("ConexionDB");
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IPersona, PersonaService>();
builder.Services.AddTransient<ISeguridad, SeguridadService>();
//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});

builder.Services.AddDbContext<RamtoDataContext>(options =>
         options.UseSqlServer(Configuraciones.CadenaConexion)
         );

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
//Cors
app.UseCors(MyAllowSpecificOrigins);
// Crea un middleware para exponer la documentación en el JSON.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
});

app.MapControllers();

app.Run();


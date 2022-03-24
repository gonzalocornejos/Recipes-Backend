using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using recipes_backend.Data;
using recipes_backend.Helpers.Middleware;
using recipes_backend.Services.Interfaces;
using recipes_backend.Services;
using recipes_backend.Repositories.Interfaces;
using recipes_backend.Repositories;
using AutoMapper;
using recipes_backend.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();


var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recetas API", Version = "v1" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Singletons for Injection Dependencies
// Services
services.AddScoped<IRecetaService, RecetaService>();
services.AddScoped<IUsuarioService, UsuarioService>();

// Repositories
services.AddScoped<IRecetaRepository, RecetaRepository>();
services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// AutoMapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

var mapper = mappingConfig.CreateMapper();
services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recetas API V1"); });
}

app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("_AllowOrigin");

app.Run();

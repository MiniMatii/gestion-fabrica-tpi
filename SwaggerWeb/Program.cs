using System;
using Alemana.Aplicaciones.Servicios;
using SwaggerWeb;
using Alemana.Data.Repositorios;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbAlemanaContext>(options =>
   options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
   ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<ILoteRepositorio, LoteRepositorio>();
builder.Services.AddScoped<ILoteServicio, LoteServicio>();





var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI();



app.MapLoteEndpoint();

app.Run();

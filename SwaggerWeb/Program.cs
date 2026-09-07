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

builder.Services.AddScoped<IProveedoresRepositorio, ProveedoresRepositorio>();
builder.Services.AddScoped<IProveedorServicio, ProveedorServicio>();

builder.Services.AddScoped<ICapacidadesRepositorio,CapacidadesRepositorio>();
builder.Services.AddScoped<ICapacidadServicio, CapacidadServicio>();

builder.Services.AddScoped<IOperarioRepositorio, OperarioRepositorio>();
builder.Services.AddScoped<IOperarioServicios, OperariosServicio>();

builder.Services.AddScoped<IMateriapRepositorio, MateriapRepositorio>();
builder.Services.AddScoped<IMateriapServicio, MateriapServicio>();
builder.Services.AddScoped<ICiudadServicio, CiudadServicio>();
builder.Services.AddScoped<ICiudadesRespositorio, CiudadesRepositorio>();

builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();
builder.Services.AddScoped<IEmpleadoServicio, EmpleadoServicio>();

builder.Services.AddScoped<ISucursalServicio, SucursalServicio>();
builder.Services.AddScoped<ISucursalRepositorio, SucursalRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

builder.Services.AddScoped<IRecetaProductoServicio, RecetaProductoServicio>();
builder.Services.AddScoped<IRecetaProductoRepositorio, RecetaProductoRepositorio>();

var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI();


app.MapOperariosEndpoint();
app.MapLoteEndpoint();
app.MapProveedorEndpoint();
app.MapMateriapEndpoint();
app.MapCapacidadesEndpoint();
app.MapEmpleadoEndpoint();
app.MapProductoEndpoint();
app.MapCiudadesEndpoint();
app.MapSucursalesEndpoint();
app.MapRecetaProductoEndpoint();

app.Run();

using System;
using Alemana.Aplicaciones.Servicios;
using SwaggerWeb;
using Alemana.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


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

builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();
builder.Services.AddScoped<IEmpleadoServicio, EmpleadoServicio>();

builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

builder.Services.AddScoped<ISucursalRepositorio, SucursalRepositorio>();
builder.Services.AddScoped<ISucursalServicio, SucursalServicio>();

builder.Services.AddScoped<ISolicitudPedidoRepositorio, SolicitudPedidoRepositorio>();
builder.Services.AddScoped<ISolicitudPedidoServicio, SolicitudPedidoServicio>();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();


//Configurando el JWT 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger(); 
app.UseSwaggerUI();



app.MapAuthEndpoints();
app.MapOperariosEndpoint();
app.MapLoteEndpoint();
app.MapProveedorEndpoint();
app.MapMateriapEndpoint();
app.MapCapacidadesEndpoint();
app.MapEmpleadoEndpoint();
app.MapProductoEndpoint();
app.MapSucursalesEndpoint();
app.MapSolicitudPedidoEndpoint();
app.Run();

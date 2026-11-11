using System;
using Alemana.Aplicaciones.Servicios;
using SwaggerWeb;
using Alemana.Data.Repositorios;
using Alemana.Data.Ado;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Pegá el token que devuelve /api/auth/login"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContext<DbAlemanaContext>(options =>
   options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
   ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Consultas con filtros en ADO.NET (capa de datos). Solo la API accede a la base.
var cadenaAdo = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Falta ConnectionStrings:DefaultConnection.");
builder.Services.AddSingleton(new AdoConexion(cadenaAdo));
builder.Services.AddScoped<OperarioAdoRepositorio>();
builder.Services.AddScoped<LoteAdoRepositorio>();
builder.Services.AddScoped<ProductoAdoRepositorio>();
builder.Services.AddScoped<SucursalAdoRepositorio>();
builder.Services.AddScoped<PedidoAdoRepositorio>();

builder.Services.AddScoped<ILoteRepositorio, LoteRepositorio>();
builder.Services.AddScoped<ILoteServicio, LoteServicio>();

builder.Services.AddScoped<IProveedoresRepositorio, ProveedoresRepositorio>();
builder.Services.AddScoped<IProveedorServicio, ProveedorServicio>();

builder.Services.AddScoped<ICapacidadesRepositorio, CapacidadesRepositorio>();
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

builder.Services.AddScoped<IRecetaProductoRepositorio, RecetaProductoRepositorio>();
builder.Services.AddScoped<IRecetaProductoServicio, RecetaProductoServicio>();

builder.Services.AddScoped<ICiudadRespositorio, CiudadRepositorio>();
builder.Services.AddScoped<ICiudadServicio, CiudadServicio>();

builder.Services.AddScoped<IOrdenProduccionRepositorio, OrdenProduccionRepositorio>();
builder.Services.AddScoped<IOrdenProduccionServicio, OrdenProduccionServicio>();

builder.Services.AddScoped<IConsumoLoteRepositorio, ConsumoLoteRepositorio>();
builder.Services.AddScoped<IConsumoLoteServicio, ConsumoLoteServicio>();

builder.Services.AddScoped<IOrdAsigOpRepositorio, OrdAsigOpRepositorio>();
builder.Services.AddScoped<IOrdAsigOpServicio, OrdAsigOpServicio>();

builder.Services.AddScoped<IStockRepositorio, StockRepositorio>();

// Validación del JWT emitido por /api/auth/login (misma configuración que usa el login)
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("Falta Jwt:Key en la configuración de la API.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.FromMinutes(1),
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    });

// Por defecto, todos los endpoints exigen un token válido.
// Los que deben ser públicos (login y registro) están marcados con AllowAnonymous.
builder.Services.AddAuthorization(o =>
    o.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();


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
app.MapRecetaProductoEndpoint();
app.MapCiudadesEndpoint();
app.MapOrdenProduccionEndpoint();
app.MapConsumoLoteEndpoint();
app.MapOrdAsigOpEndpoint();
app.MapConsultasAdoEndpoints();

app.Run();
using Alemana.Web.Auth;
using Alemana.Web.Components;
using Alemana.Web.Datos;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Acceso a datos con ADO.NET (MySqlConnector). Sin Entity Framework ni llamadas a la API.
builder.Services.AddScoped<DbConexion>();
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<OperarioRepositorio>();
builder.Services.AddScoped<LoteRepositorio>();
builder.Services.AddScoped<ProductoRepositorio>();
builder.Services.AddScoped<SucursalRepositorio>();
builder.Services.AddScoped<PedidoRepositorio>();

builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("Autenticado", p => p.RequireAuthenticatedUser());
    o.AddPolicy("VerPedidosAsignados", p => p.RequireRole("Operario"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AllowAnonymous();

app.Run();

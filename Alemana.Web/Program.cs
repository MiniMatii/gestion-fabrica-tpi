using Alemana.API;
using Alemana.Web.Components;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Alemana.Web.Auth;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//
builder.Services.AddScoped(sp =>
{
    var handler = new TokenHandler(sp.GetRequiredService<ILocalStorageService>())
    {
        InnerHandler = new HttpClientHandler()
    };

    var http = new HttpClient(handler)
    {
        BaseAddress = new Uri("https://localhost:7150/")   // el mismo puerto que usa el escritorio
    };

    return new ApiClient(http);
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("Autenticado", p => p.RequireAuthenticatedUser());
    //o.AddPolicy("GenerarPedidos", p => p.RequireRole("Empleado"));
    o.AddPolicy("VerPedidosAsignados", p => p.RequireRole("Operario"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AllowAnonymous();



app.Run();

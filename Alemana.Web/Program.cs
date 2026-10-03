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
builder.Services.AddHttpClient("Api", c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiBaseUri"]!));

builder.Services.AddScoped(sp =>
    new ApiClient(sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api")));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

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
    .AddInteractiveServerRenderMode();

app.Run();

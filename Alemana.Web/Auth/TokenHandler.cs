using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Alemana.Web.Auth;

public class TokenHandler : DelegatingHandler
{
    private readonly ILocalStorageService _storage;

    public TokenHandler(ILocalStorageService storage) => _storage = storage;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken ct)
    {
        try
        {
            var token = await _storage.GetItemAsync<string>("authToken", ct);
            if (!string.IsNullOrEmpty(token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        catch (InvalidOperationException)
        {
            // Sin JavaScript disponible todavía: se envía sin token
        }

        return await base.SendAsync(request, ct);
    }
}
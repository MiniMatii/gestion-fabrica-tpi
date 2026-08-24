using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alemana.APIs
{
    public abstract class BaseApiClient
    {
        protected static async Task<HttpClient> CreateHttpClientAsync()
        {
            var client = new HttpClient();
            await ConfigureHttpClientAsync(client);
            return client;
        }

        protected static async Task ConfigureHttpClientAsync(HttpClient client)
        {
            // Leer URL base de configuración, si no existe usar localhost por defecto
            string baseUrl = GetBaseUrlFromConfig();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // Agregar Bearer token automáticamente si está autenticado
           // await AddAuthorizationHeaderAsync(client);
        }

        private static string GetBaseUrlFromConfig()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Intentando leer configuración...");

                // 1. Primero revisar variable de entorno
                string? envUrl = Environment.GetEnvironmentVariable("TPI_API_BASE_URL");
                if (!string.IsNullOrEmpty(envUrl))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] URL desde variable de entorno: {envUrl}");
                    return envUrl;
                }

                // 2. Detectar si estamos en Android por el runtime
                string runtimeInfo = System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier;
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Runtime: {runtimeInfo}");

                if (runtimeInfo.StartsWith("android"))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Detectado Android - usando IP de emulador");
                    return "http://10.0.2.2:5183/";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Error detectando plataforma: {ex.Message}");
            }

            // URL por defecto para Windows/otras plataformas
            string defaultUrl = "http://localhost:7150/";
            System.Diagnostics.Debug.WriteLine($"[DEBUG] Usando URL por defecto: {defaultUrl}");
            return defaultUrl;
        }

        protected async Task<T?> GetAsync<T>(string endpoint)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.GetAsync(endpoint);

            EnsureSuccess(response);

            // Deserializa el JSON automáticamente al objeto que le pidas
            return await response.Content.ReadFromJsonAsync<T>();
        }

        // 2. POST: Crear un registro nuevo y devolver el resultado
        protected async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync(endpoint, data);

            EnsureSuccess(response);

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        // 3. PUT: Actualizar un registro (como el de BajaEmpleado)
        protected async Task PutAsync<TRequest>(string endpoint, TRequest data)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync(endpoint, data);

            EnsureSuccess(response);
        }

        // 4. DELETE: Borrar un registro
        protected async Task DeleteAsync(string endpoint)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync(endpoint);

            EnsureSuccess(response);
        }

        // 5. Manejo centralizado de errores
        private void EnsureSuccess(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                // Acá centralizás qué pasa si la API te devuelve un 400 BadRequest o 404 NotFound.
                // Podés leer el mensaje de error del backend y lanzar una excepción para que WinForms muestre un MessageBox.
                throw new HttpRequestException($"Error en la comunicación con el servidor. Código: {response.StatusCode}");
            }
        }
    }
}
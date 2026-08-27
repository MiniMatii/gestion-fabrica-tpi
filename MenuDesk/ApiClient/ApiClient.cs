using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MenuDesk.Services
{
    public class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7150/")
        };
        public async Task<List<T>?> ObtenerListaAsync<T>(string endpoint)
        {
            try
            {
                return await _client.GetFromJsonAsync<List<T>>(endpoint);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar con la API en '{endpoint}': {ex.Message}");
            }
        }

        public async Task<bool> PostAsync<T>(string endpoint, T objetoDto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(endpoint, objetoDto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al enviar datos a '{endpoint}': {ex.Message}");
            }
        }
    }
}
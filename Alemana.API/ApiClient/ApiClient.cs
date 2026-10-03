using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Alemana.API
{
    public class ApiClient
    {
        private static readonly HttpClient _clientEscritorio = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7150/")
        };

        public ApiClient() : this(_clientEscritorio) { }


        //web
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }
        
        public string? Token
        {
            set => _client.DefaultRequestHeaders.Authorization = value is null
                ? null
                : new AuthenticationHeaderValue("Bearer", value);
        }

        public async Task<LoginRespuestaDTO?> LoginAsync(LoginDTO dto)
        {
            var response = await _client.PostAsJsonAsync("api/auth/login", dto);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;   

            if (!response.IsSuccessStatusCode)
                throw new Exception(
                    $"Login falló: {(int)response.StatusCode} - {await response.Content.ReadAsStringAsync()}");

            return await response.Content.ReadFromJsonAsync<LoginRespuestaDTO>();
        }

        //
        public async Task<List<T>?> ObtenerListaAsync<T>(string endpoint)
        {
            try
            {
                return await _clientEscritorio.GetFromJsonAsync<List<T>>(endpoint);
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

        public async Task<bool> PatchAsync<T>(string endpoint, T objetoDto)
        {
            try
            {
                var response = await _client.PatchAsJsonAsync(endpoint, objetoDto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualiar algunos campos en '{endpoint}': {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await _client.DeleteAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Status: {response.StatusCode}\nContenido: {contenido}");
                }


                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Excepción: {ex.Message}\nInner: {ex.InnerException?.Message}");
            }
        }




    }
}
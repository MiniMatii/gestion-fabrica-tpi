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

        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public string? Token
        {
            get => _client.DefaultRequestHeaders.Authorization?.Parameter;
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
                throw new Exception($"Login falló: {(int)response.StatusCode} - {await response.Content.ReadAsStringAsync()}");

            var result = await response.Content.ReadFromJsonAsync<LoginRespuestaDTO>();
            Token = result?.Token;   
            return result;
        }

        public void Logout() => Token = null;

        
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

        public async Task<bool> PutAsync<T>(string endpoint, T objetoDto)
        {
            try
            {
                var response = await _client.PutAsJsonAsync(endpoint, objetoDto);

                if (!response.IsSuccessStatusCode)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Status: {response.StatusCode}\nContenido: {contenido}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar datos en '{endpoint}': {ex.Message}");
            }
        }

        public async Task<T> ObtenerAsync<T>(string endpoint)
        {
            try
            {
                var response = await _client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Status: {response.StatusCode}\nContenido: {contenido}");
                }

                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener datos de '{endpoint}': {ex.Message}");
            }
        }

        public async Task<(bool Ok, HttpStatusCode Status, string? Mensaje)> PostConRespuestaAsync<T>(string endpoint, T objetoDto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(endpoint, objetoDto);

                if (response.IsSuccessStatusCode)
                    return (true, response.StatusCode, null);

                var texto = await response.Content.ReadAsStringAsync();

                string mensaje = texto;
                try { mensaje = System.Text.Json.JsonSerializer.Deserialize<string>(texto) ?? texto; }
                catch { }

                return (false, response.StatusCode, mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al enviar datos a '{endpoint}': {ex.Message}");
            }
        }



    }
}
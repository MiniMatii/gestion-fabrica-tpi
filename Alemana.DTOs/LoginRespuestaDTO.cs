

namespace Alemana.DTOs
{
    public class LoginRespuestaDTO
    {
        public string Token { get; set; } = string.Empty;
        //public DateTime ExpiresAt { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}

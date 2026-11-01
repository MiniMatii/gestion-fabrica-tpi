namespace Alemana.Web.Auth;

/// <summary>Datos de la sesión iniciada. Se guarda cifrada en el navegador.</summary>
public record SesionUsuario(int IdUsuario, string Nombre, string Rol, int? IdOperario, int? IdEmpleado);

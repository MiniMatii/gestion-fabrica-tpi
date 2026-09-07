using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IMateriapServicio
    {
        Task<MateriapDTO> AgregarMateriaPrima(MateriapDTO dto);
        Task<List<MateriapDTO>> ObtenerTodos();
        Task<MateriapDTO> ObtenerPorId(int id);
        Task<MateriapDTO> ModificarMateriaPrima(MateriapDTO dto);
    }
}
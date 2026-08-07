using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IMateriapServicio
    {
        Task<MateriaPrimaDTO> AgregarMateriaPrima(MateriaPrimaDTO dto);
        Task<List<MateriaPrimaDTO>> ObtenerTodos();
        Task<MateriaPrimaDTO> ObtenerPorId(int id);
        Task<MateriaPrimaDTO> ModificarMateriaPrima(MateriaPrimaDTO dto);
    }
}
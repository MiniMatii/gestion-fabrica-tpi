using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IProveedorServicio
    {

        Task<ProveedorDTO> AgregarProveedor(ProveedorDTO unProvDTO);
        Task<List<ProveedorDTO>> ObtenerTodos();
        Task<ProveedorDTO> ObtenerPorId(int id);
        Task<ProveedorDTO> ModificarProveedor(ProveedorDTO proveedorDTO);

    }
}

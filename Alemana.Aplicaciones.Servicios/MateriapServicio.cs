using Alemana.Dominio.Models;
using Alemana.DTOs;
using Alemana.Data.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class MateriapServicio : IMateriapServicio
    {
        private readonly IMateriapRepositorio materiapRepositorio;

        public MateriapServicio(IMateriapRepositorio materiapRepo)
        {
            materiapRepositorio = materiapRepo;
        }

        public async Task<MateriaPrimaDTO> AgregarMateriaPrima(MateriaPrimaDTO unaMatpDTO)
        {
            Materiap nMateriap = new Materiap
            {
                IdMateriaP = unaMatpDTO.IdMateriaP,
                Nombre = unaMatpDTO.Nombre,
                Unidad = unaMatpDTO.Unidad
            };

            await materiapRepositorio.AgregarMateriaPrima(nMateriap);
            unaMatpDTO.IdMateriaP = nMateriap.IdMateriaP;

            return unaMatpDTO;
        }

        public async Task<List<MateriaPrimaDTO>> ObtenerTodos()
        {
            var materiasPrimas = await materiapRepositorio.ObtenerTodos();

            // Transformamos la lista de entidades a una lista de DTOs
            return materiasPrimas.Select(m => new MateriaPrimaDTO
            {
                IdMateriaP = m.IdMateriaP,
                Nombre = m.Nombre,
                Unidad = m.Unidad
            }).ToList();
        }

        public async Task<MateriaPrimaDTO> ObtenerPorId(int id)
        {
            var materiaPrima = await materiapRepositorio.ObtenerPorId(id);

            if (materiaPrima == null) return null;

            return new MateriaPrimaDTO
            {
                IdMateriaP = materiaPrima.IdMateriaP,
                Nombre = materiaPrima.Nombre,
                Unidad = materiaPrima.Unidad
            };
        }

        public async Task<MateriaPrimaDTO> ModificarMateriaPrima(MateriaPrimaDTO unaMatpDTO)
        {
            var matExistente = await materiapRepositorio.ObtenerPorId(unaMatpDTO.IdMateriaP);

            if (matExistente == null)
            {
                throw new ArgumentException("La materia prima que intenta modificar no existe.");
            }

            matExistente.Nombre = unaMatpDTO.Nombre;
            matExistente.Unidad = unaMatpDTO.Unidad;

            await materiapRepositorio.ModificarMateriaPrima(matExistente);

            return unaMatpDTO;
        }
    }
}
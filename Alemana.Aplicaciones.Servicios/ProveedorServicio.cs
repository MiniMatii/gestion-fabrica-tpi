using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class ProveedorServicio : IProveedorServicio
    {
        private readonly IProveedoresRepositorio provRepositorio;

        public ProveedorServicio(IProveedoresRepositorio provRepo)
        {
            provRepositorio = provRepo;
        }

        public async Task<ProveedorDTO> AgregarProveedor(ProveedorDTO unProvDTO)
        {
            Proveedore nProveedor = new Proveedore
            {
                IdProveedor = unProvDTO.IdProveedor,
                RazonSocial = unProvDTO.RazonSocial,
                Cuit = unProvDTO.Cuit,
                Nombre = unProvDTO.Nombre,
            };

            await provRepositorio.AgregarProveedor(nProveedor);
            unProvDTO.IdProveedor = nProveedor.IdProveedor;


            return unProvDTO;
        }

        public async Task<List<ProveedorDTO>> ObtenerTodos()
        {
            var proveedores = await provRepositorio.ObtenerTodos();

            return proveedores.Select(p => new ProveedorDTO
            {
                IdProveedor = p.IdProveedor,
                RazonSocial = p.RazonSocial,
                Cuit = p.Cuit,
                Nombre = p.Nombre
            }).ToList();
        }

        public async Task<ProveedorDTO> ObtenerPorId(int id)
        {
            var proveedor = await provRepositorio.ObtenerPorId(id);

            if (proveedor == null) return null;

            return new ProveedorDTO
            {
                IdProveedor = proveedor.IdProveedor,
                RazonSocial = proveedor.RazonSocial,
                Cuit = proveedor.Cuit,
                Nombre = proveedor.Nombre
            };
        }

        public async Task<ProveedorDTO> ModificarProveedor(ProveedorDTO unProvDTO)
        {
            var proveedorExistente = await provRepositorio.ObtenerPorId(unProvDTO.IdProveedor);

            if (proveedorExistente == null)
            {
                throw new ArgumentException("El proveedor que intenta modificar no existe.");
            }

            proveedorExistente.RazonSocial = unProvDTO.RazonSocial;
            proveedorExistente.Cuit = unProvDTO.Cuit;
            proveedorExistente.Nombre = unProvDTO.Nombre;

            await provRepositorio.ModificarProveedor(proveedorExistente);

            return unProvDTO;
        }

    }
}
using Alemana.Dominio.Models;
using Alemana.DTOs;
using Alemana.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private readonly IEmpleadoRepositorio empRepositorio;

        public EmpleadoServicio(IEmpleadoRepositorio empRepo)
        {
            empRepositorio = empRepo;
        }

        public async Task<EmpleadoDTO> AgregarEmpleado(EmpleadoDTO unEmpDTO)
        {
            Empleado nEmpleado = new Empleado
            {
                IdEmpleado = unEmpDTO.IdEmpleado,
                Nombre = unEmpDTO.Nombre,
                Apellido = unEmpDTO.Apellido,
                Dni = unEmpDTO.Dni,
                IdSucursal = unEmpDTO.IdSucursal,
                IdJefe = unEmpDTO.IdJefe,
                Disponibilidad = 1,
                Motivo = null
            };

            await empRepositorio.AgregarEmpleado(nEmpleado);
            unEmpDTO.IdEmpleado = nEmpleado.IdEmpleado;
            unEmpDTO.Disponibilidad = 1;

            return unEmpDTO;
        }

        public async Task<List<EmpleadoDTO>> ObtenerTodos()
        {
            var empleados = await empRepositorio.ObtenerTodos();

            return empleados.Select(e => new EmpleadoDTO
            {
                IdEmpleado = e.IdEmpleado,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Dni = e.Dni,
                IdSucursal = e.IdSucursal,
                IdJefe = e.IdJefe,
                Disponibilidad = e.Disponibilidad,
                Motivo = e.Motivo
            }).ToList();
        }

        public async Task<EmpleadoDTO> ObtenerPorId(int id)
        {
            var empleado = await empRepositorio.ObtenerPorId(id);

            if (empleado == null) return null;

            return new EmpleadoDTO
            {
                IdEmpleado = empleado.IdEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Dni = empleado.Dni,
                IdSucursal = empleado.IdSucursal,
                IdJefe = empleado.IdJefe,
                Disponibilidad = empleado.Disponibilidad,
                Motivo = empleado.Motivo
            };
        }

        public async Task<EmpleadoDTO> ModificarEmpleado(EmpleadoDTO unEmpDTO)
        {
            var empExistente = await empRepositorio.ObtenerPorId(unEmpDTO.IdEmpleado);

            if (empExistente == null)
            {
                throw new ArgumentException("El empleado que intenta modificar no existe.");
            }

            empExistente.Nombre = unEmpDTO.Nombre;
            empExistente.Apellido = unEmpDTO.Apellido;
            empExistente.Dni = unEmpDTO.Dni;
            empExistente.IdSucursal = unEmpDTO.IdSucursal;
            empExistente.IdJefe = unEmpDTO.IdJefe;    

            await empRepositorio.ModificarEmpleado(empExistente);

            return unEmpDTO;
        }

        public async Task<EmpleadoDTO> BajaEmpleado(EmpleadoDTO unEmpDTO)
        {
            var empExistente = await empRepositorio.ObtenerPorId(unEmpDTO.IdEmpleado);

            if (empExistente == null)
            {
                throw new ArgumentException("El empleado que intenta dar de baja no existe.");
            }

            empExistente.Disponibilidad = 0;
            empExistente.Motivo = unEmpDTO.Motivo;

            await empRepositorio.ModificarEmpleado(empExistente);

            unEmpDTO.Disponibilidad = 0;
            return unEmpDTO;
        }
    }
}
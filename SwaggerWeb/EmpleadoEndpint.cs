using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SwaggerWeb
{
    public static class EmpleadoEndpoint
    {
        public static void MapEmpleadoEndpoint(this WebApplication app)
        {
            app.MapPost("/empleado", async (EmpleadoDTO dto, IEmpleadoServicio empleadoServicio) =>
            {
                try
                {
                    EmpleadoDTO nuevoEmpleado = await empleadoServicio.AgregarEmpleado(dto);
                    return Results.Created($"/empleado/{nuevoEmpleado.IdEmpleado}", nuevoEmpleado);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Alta Empleado").WithTags("Empleados").WithOpenApi();


            app.MapGet("/empleado", async (IEmpleadoServicio empleadoServicio) =>
            {
                var empleados = await empleadoServicio.ObtenerTodos();
                return Results.Ok(empleados);
            }).WithName("Obtener Empleados").WithTags("Empleados").WithOpenApi();


            app.MapGet("/empleado/{id}", async (int id, IEmpleadoServicio empleadoServicio) =>
            {
                var empleado = await empleadoServicio.ObtenerPorId(id);
                if (empleado == null) return Results.NotFound(new { mensaje = "Empleado no encontrado" });

                return Results.Ok(empleado);
            }).WithName("Obtener Empleado Por Id").WithTags("Empleados").WithOpenApi();


            app.MapPut("/empleado/{id}", async (int id, EmpleadoDTO dto, IEmpleadoServicio empleadoServicio) =>
            {
                try
                {
                    if (id != dto.IdEmpleado) return Results.BadRequest(new { error = "El ID no coincide." });

                    EmpleadoDTO empActualizado = await empleadoServicio.ModificarEmpleado(dto);
                    return Results.Ok(empActualizado);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
            }).WithName("Modificar Empleado").WithTags("Empleados").WithOpenApi();

            app.MapPut("/empleado/baja/{id}", async (int id, EmpleadoDTO dto, IEmpleadoServicio empleadoServicio) =>
            {
                if (id != dto.IdEmpleado) return Results.BadRequest(new { error = "El ID no coincide." });

                bool dadoDeBaja = await empleadoServicio.BajaEmpleado(dto);

                if (!dadoDeBaja) return Results.NotFound(new { error = "Empleado no encontrado." });

                return Results.Ok(new { mensaje = "Empleado dado de baja exitosamente." });
            }).WithName("Dar de Baja Empleado").WithTags("Empleados").WithOpenApi();
        }
    }
}
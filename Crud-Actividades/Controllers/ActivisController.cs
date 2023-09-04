﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Crud_Actividades.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Actividades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivisController : ControllerBase
    {
        readonly DbActividadesContext _actividadesContext;
        enum status
        {
            ACTIVO,
            INACTIVA
        }
        public ActivisController(DbActividadesContext _actividadesContext)
        {
            this._actividadesContext = _actividadesContext;
        }

        [HttpGet]
        public async Task<IActionResult> Getpropietys()
        {
            var propiedades = _actividadesContext.Properties.AsNoTracking();

            return StatusCode(StatusCodes.Status200OK, propiedades);

        }
        [HttpPost]
        public async Task<IActionResult> Agregar_Actividad(NewActivityDTO Actividad)
        {
            DateTime inicio_cita = Actividad.Schedule;
            DateTime Fin_cita = Actividad.Schedule.AddHours(1);

            int id = Actividad.PropertyId;

            var find_propiedad = await _actividadesContext.Properties.FindAsync(id);

            var find_Actividad = _actividadesContext.Activities.
            Where(
            x => x.PropertyId == id && x.Schedule 
            <= Fin_cita && x.Schedule.AddHours(1) >= inicio_cita
            );

            if (find_Actividad.Any())
            {
                var res = new
                {
                    Message ="Horario de cita no disponible"
                };

                return StatusCode(StatusCodes.Status400BadRequest, res);
            }

            if (find_propiedad == null || find_propiedad.Status == status.INACTIVA.ToString())
            {
                var res = new
                {
                    Message = "Propiedad no encontrada o propiedad desactivada"
                };
                return StatusCode(StatusCodes.Status400BadRequest,res);
            }

            else
            {
                var nueva_actividad = new Activity
                {
                    CreatedAt = DateTime.UtcNow,
                    PropertyId = Actividad.PropertyId,
                    Status = Actividad.Status,
                    Title = Actividad.Title,
                    UpdatedAt = DateTime.UtcNow,
                    Schedule = Actividad.Schedule,
                };

                await _actividadesContext.Activities.AddAsync(nueva_actividad);
                await _actividadesContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK);
            }
          
        }
        [HttpPut]
        public async Task<IActionResult> Editar_Actividad(int id, DateTime NuevaFecha)
        {
            DateTime inicio_cita = NuevaFecha;
            DateTime Fin_cita = NuevaFecha.AddHours(1);

            var actividad = await _actividadesContext.Activities.FindAsync(id);



           var find_Actividad = _actividadesContext.Activities.
           Where(
           x => x.PropertyId == id && x.Schedule
           <= Fin_cita && x.Schedule.AddHours(1) >= inicio_cita
           );

            if (find_Actividad.Any())
            {
                var res = new
                {
                    Message = "Horario de cita no disponible"
                };

                return StatusCode(StatusCodes.Status400BadRequest, res);
            }


            if (actividad == null || actividad.Status!= status.ACTIVO.ToString())
            {
                var res = new
                {
                    Message = "No se puede Reangendar Actividades Canceladas o Actividades que no existen"
                };
                return StatusCode(StatusCodes.Status404NotFound, res);
            }
            else
            {

                actividad.Schedule = NuevaFecha;
                await _actividadesContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK);
            }
        }
    }
}

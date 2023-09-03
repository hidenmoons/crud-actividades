using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AgregarActividad(ActivityDTO Actividad)
        {
            int id = Actividad.PropertyId;

            var find_propiedad = await _actividadesContext.Properties.FindAsync(id);

            if (find_propiedad == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,"Propiedad no encontrada");
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
                return StatusCode(StatusCodes.Status200OK, nueva_actividad);
            }

         

          
        }
    }
}

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
    }
}

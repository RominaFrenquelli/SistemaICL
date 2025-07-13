using ICL.Business;
using ICL.Data;
using ICL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly SolicitudBusiness _solicitudBusiness;

        public SolicitudController(SolicitudBusiness solicitudBusiness)
        {
            _solicitudBusiness = solicitudBusiness;
        }

        [HttpPost(Name = "CrearSolicitud")]
        public IActionResult CrearSolicitudNueva(Solicitud nueva)
        {
            try
            {
                if(nueva == null || nueva.Pedidos == null || nueva.Pedidos.Count() == 0)
                {
                    return BadRequest("Debe haber al menos un pedido asociado a la solicitud.");
                }


                var idSolicitud = _solicitudBusiness.CrearSolicitud(nueva, nueva.Pedidos);

                return Ok(new { idSolicitud });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "ObtenerSolicitud")]
        public IActionResult ObtenerSolicitud(int idSolicitud)
        {
            try
            {
                if(idSolicitud == 0)
                {
                    return BadRequest("No se encontraron resultados para esta consulta.");
                }

                Solicitud Solicitud = _solicitudBusiness.ObtenerSolicitud(idSolicitud);

                return Ok(Solicitud);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }


    }
}

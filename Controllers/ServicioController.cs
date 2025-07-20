using ICL.Business;
using ICL.Data;
using ICL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ServicioBusiness _servicioBusiness;

        public ServicioController(ServicioBusiness servicioBusiness)
        {
            _servicioBusiness = servicioBusiness;
        }

        [HttpPost (Name = "Crear Servicio")]
        public async Task<IActionResult> CrearServicio(Servicio nuevo)
        {
            try
            {
                var id = await _servicioBusiness.CrearServicio (nuevo);
                return Ok(new { Id = id, Mensaje = "El servicio se creo correctamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name ="Lista de servicios")]
        public async Task<IActionResult> ListarServicio()
        {
            try
            {
                var lista = await _servicioBusiness.ListarServicio();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name ="ObtenerPorIds")]
        public async Task<IActionResult> ObtenerPorIds(List<int> ids)
        {
            var listaIds = await _servicioBusiness.ObtenerPorIds (ids);
            return Ok(listaIds);
        }
    }
}

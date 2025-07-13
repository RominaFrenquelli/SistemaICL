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

        public ServicioController(ICLContext context)
        {
            _servicioBusiness = new ServicioBusiness(context);
        }

        [HttpPost (Name = "Crear Servicio")]
        public IActionResult CrearServicio(Servicio nuevo)
        {
            try
            {
                var id = _servicioBusiness.CrearServicio (nuevo);
                return Ok(new { Id = id, Mensaje = "El servicio se creo correctamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name ="Lista de servicios")]
        public IActionResult ListarServicio()
        {
            try
            {
                var lista = _servicioBusiness.ListarServicio();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

using ICL.Business;
using ICL.Data;
using ICL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteBusiness _clienteBusiness;

        public ClienteController(ICLContext context)
        {
            _clienteBusiness = new ClienteBusiness(context);
        }

        [HttpPost(Name = "CrearCliente")]
        public IActionResult CrearClientes(Cliente elCLienteDelHtml)
        {
            try
            {
                // 1 - Crear clientes
                var idDelCLiente = _clienteBusiness.CrearCliente(elCLienteDelHtml);

                // 2 - Retornar ok
                return Ok(idDelCLiente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet(Name = "ObtenerClientes")]
        public IActionResult ObtenerClientes()
        {
            // 1 - Obtener clientes
            var clientes = _clienteBusiness.ObtenerClientes();

            // 2 - Retornar los clientes

            if (clientes.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(clientes);
            }
        }

        [HttpGet(Name = "BuscarClientes")]
        public IActionResult BuscarClientes(string nombre)
        {

            var clientes = _clienteBusiness.BuscarClientes(nombre);


            if (clientes.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(clientes);
            }


        }
    }
}

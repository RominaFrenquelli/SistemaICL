using ICL.Business;
using ICL.Data;
using ICL.Interfaces;
using ICL.Models;
using ICL.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoPostulanteController : ControllerBase
    {
        private readonly IPedidoPostulanteBusiness _postulanteBusiness;

        public PedidoPostulanteController(IPedidoPostulanteBusiness pedidoPostulanteBusiness)
        {
            _postulanteBusiness = pedidoPostulanteBusiness;
        }

        [HttpPost(Name = "CrearPedido")]
        public async Task<IActionResult> CrearPedidoPostulante([FromBody] CrearPedidoPostulanteDTO dto)
        {
            try
            {
                var pedido = PedidoPostulante.CrearNuevo(
                    dto.Nombre,
                    dto.Apellido,
                    dto.DNI,
                    dto.FechaDeNacimiento,
                    dto.Observaciones,
                    dto.SolicitudId,
                    dto.ServiciosId
                );
                var id = await _postulanteBusiness.CrearPostulante(pedido);
                return Ok(new { Id = id, Mensaje = "Pedido creado correctamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarPedido(int id, PedidoPostulante pedidoActualizado)
        {
            try
            {
                await _postulanteBusiness.EditarPedido(id, pedidoActualizado);
                return Ok("Pedido actualizado correctamente");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPedidoFisico(int id)
        {
            try
            {
                await _postulanteBusiness.EliminarPedidoFisico(id);
                return Ok("Pedido eliminado");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar-logico/{id}")]
        public async Task<IActionResult> EliminarPedidoLogico(int id)
        {
            try
            {
                await _postulanteBusiness.PedidoEliminarLogico(id);
                return Ok(new{mensaje = "Pedido eliminado correctamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPedido(int id)
        {
            try
            {
                var pedido = await _postulanteBusiness.BuscarPorId(id);

                if(pedido == null)
                    return NotFound("No se encontro el pedido");

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "ListaDePedidos")]
        public async Task<IActionResult> ListarPedidos()
        {
            try
            {
                var listado = await _postulanteBusiness.ListarPedidos();
                return Ok(listado);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarDni/{DNI}")]
        public async Task<IActionResult> BuscarPorDni(string dni)
        {
            try
            {
                var postulante = await _postulanteBusiness.BuscarPorDNI(dni);

                if (postulante == null)
                    return NotFound("No se encontró un pedido con ese DNI.");


                return Ok(postulante);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Reactivar{id}")] 
        public async Task<IActionResult> ReactivarPedido(int id)
        {
            try
            {
                await _postulanteBusiness.ReactivarPerdido(id);
                return Ok(new {mensaje="El pedido se reactivo correctamente"});
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
    }
}

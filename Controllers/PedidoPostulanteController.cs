using ICL.Business;
using ICL.Data;
using ICL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoPostulanteController : ControllerBase
    {
        private readonly PedidoPostulanteBusiness _postulanteBusiness;

        public PedidoPostulanteController(PedidoPostulanteBusiness pedidoPostulanteBusiness)
        {
            _postulanteBusiness = pedidoPostulanteBusiness;
        }

        
    }
}

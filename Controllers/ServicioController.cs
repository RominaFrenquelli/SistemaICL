using ICL.Business;
using ICL.Data;
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
    }
}

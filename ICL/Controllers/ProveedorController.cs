using ICL.Business;
using ICL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorBusiness _proveedorBusiness;

        public ProveedorController(ICLContext context)
        {
            _proveedorBusiness = new ProveedorBusiness(context);
        }
    }
}

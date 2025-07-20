using ICL.Business;
using ICL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedactorController : ControllerBase
    {
        private readonly RedactorBusiness _redactorBusiness;

        public RedactorController(ICLContext context)
        {
            _redactorBusiness = new RedactorBusiness(context);
        }
    }
}

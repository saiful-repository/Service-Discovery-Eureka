using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Gateway is running.");
    }
}

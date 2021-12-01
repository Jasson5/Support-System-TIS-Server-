using Microsoft.AspNetCore.Mvc;

namespace Support_System_Server_v2.Controllers
{

    [Route("api/health-check")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Service running.");
        }
    }
}
